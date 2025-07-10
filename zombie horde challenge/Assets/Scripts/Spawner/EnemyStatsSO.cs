using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "Enemy/Basic Enemy Stats")]
public class EnemyStatsSO : ScriptableObject
{
    public float Health;
    public float speed;
    public float damage;
    public Color color;
}
