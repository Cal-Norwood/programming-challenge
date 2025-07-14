using UnityEngine;

[CreateAssetMenu(fileName = "defaultWave", menuName = "Wave/Wave Stats")]
public class WaveStatsSO : ScriptableObject // allows for easy wave creation
{
    public int EasyEnemyCount;
    public int MediumEnemyCount;
    public int HardEnemyCount;

    public int TotalEnemyCount;
}
