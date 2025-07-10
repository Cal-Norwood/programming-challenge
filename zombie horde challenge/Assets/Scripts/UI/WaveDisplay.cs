using UnityEngine;
using TMPro;

public class WaveDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_CurrentWave;
    [SerializeField] TextMeshProUGUI m_WaveLevel;
    [SerializeField] TextMeshProUGUI m_EnemiesLeft;

    [SerializeField] private EnemySpawnerSystem m_ESS;

    private void OnEnable()
    {
        m_ESS.UpdateWave += UpdateCurrentWave;
        m_ESS.UpdateWaveLevel += UpdateWaveLevel;
        m_ESS.UpdateEnemiesLeft += UpdateEnemiesRemain;
    }

    private void OnDisable()
    {
        m_ESS.UpdateWave -= UpdateCurrentWave;
        m_ESS.UpdateWaveLevel -= UpdateWaveLevel;
        m_ESS.UpdateEnemiesLeft -= UpdateEnemiesRemain;
    }

    private void UpdateCurrentWave(int currentWave)
    {
        switch(currentWave)
        {
            case 0: m_CurrentWave.text = "Current Wave: Easy";
                break;

            case 1: m_CurrentWave.text = "Current Wave: Medium";
                break;

            case 2: m_CurrentWave.text = "Current Wave: Hard";
                break;
        }
    }

    private void UpdateWaveLevel(int waveLevel)
    {
        m_WaveLevel.text = "Wave Level: " + waveLevel.ToString();
    }

    private void UpdateEnemiesRemain(int enemiesLeft)
    {
        m_EnemiesLeft.text = "Enemies Remain " + enemiesLeft.ToString();
    }
}
