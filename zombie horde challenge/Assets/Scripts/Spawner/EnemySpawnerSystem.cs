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
    private int m_waveLevel = 1;

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
        m_EnemiesRemain = m_WaveStats[m_CurrentWave].TotalEnemyCount;

        UpdateWave?.Invoke(m_CurrentWave);
        UpdateWaveLevel?.Invoke(m_waveLevel);
        UpdateEnemiesLeft?.Invoke(m_EnemiesRemain);

        for (int i = 0; i < m_WaveStats[m_CurrentWave].EasyEnemyCount * m_waveLevel; i++)
        {
            yield return new WaitForSeconds(0.1f);
            SpawnEnemy(0);
        }

        for (int i = 0; i < m_WaveStats[m_CurrentWave].MediumEnemyCount * m_waveLevel; i++)
        {
            yield return new WaitForSeconds(0.1f);
            SpawnEnemy(1);
        }

        for (int i = 0; i < m_WaveStats[m_CurrentWave].HardEnemyCount * m_waveLevel; i++)
        {
            yield return new WaitForSeconds(0.1f);
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
    }

    //keep reference to active enemies to be able to unbind on disable
}
