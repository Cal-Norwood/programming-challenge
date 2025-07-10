using UnityEngine;
using System.Collections;
using System;

public class EnemySpawnerSystem : MonoBehaviour
{
    [SerializeField] private GameObject m_BaseEnemy;
    [SerializeField] private EnemyStatsSO[] m_ES;
    [SerializeField] private WaveStatsSO[] m_WaveStats;
    [SerializeField] private GameObject m_Player;

    public Action<int> UpdateWave;
    public Action<int> UpdateWaveLevel;
    public Action<int> UpdateEnemiesLeft;

    private int m_CurrentWave = 0;
    private int m_WaveLevel = 1;

    private int m_EnemiesRemain;

    private void Awake()
    {
        StartCoroutine(WaveSpawner());
    }

    private void OnEnable()
    {
        
    }

    private IEnumerator WaveSpawner()
    {
        m_EnemiesRemain = m_WaveStats[m_CurrentWave].TotalEnemyCount * m_WaveLevel;

        UpdateWave?.Invoke(m_CurrentWave);
        UpdateWaveLevel?.Invoke(m_WaveLevel);
        UpdateEnemiesLeft?.Invoke(m_EnemiesRemain);

        for (int i = 0; i < m_WaveStats[m_CurrentWave].EasyEnemyCount * m_WaveLevel; i++)
        {
            yield return new WaitForSeconds(0.25f);
            SpawnEnemy(0);
        }

        for (int i = 0; i < m_WaveStats[m_CurrentWave].MediumEnemyCount * m_WaveLevel; i++)
        {
            yield return new WaitForSeconds(0.25f);
            SpawnEnemy(1);
        }

        for (int i = 0; i < m_WaveStats[m_CurrentWave].HardEnemyCount * m_WaveLevel; i++)
        {
            yield return new WaitForSeconds(0.25f);
            SpawnEnemy(2);
        }
    }

    private void SpawnEnemy(int difficulty)
    {
        Vector3 randomPos = UnityEngine.Random.insideUnitCircle.normalized * 12;
        GameObject enemy = Instantiate(m_BaseEnemy, (m_Player.transform.position + randomPos), Quaternion.identity);
        EnemyHandler EH = enemy.GetComponent<EnemyHandler>();
        EH.Initialize(m_ES[difficulty]);
        EH.EnemyDead += EnemyDead;
    }

    private void EnemyDead()
    {
        m_EnemiesRemain--;
        UpdateEnemiesLeft?.Invoke(m_EnemiesRemain);

        if(m_EnemiesRemain == 0)
        {
            m_WaveLevel++;

            if(m_WaveLevel == 10)
            {
                Debug.Log("next wave");
            }
            else
            {
                StartCoroutine(WaveSpawner());
            }
        }
    }
}
