using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "Enemy/Basic Enemy Stats")]
public class EnemyStatsSO : ScriptableObject // allows for easy enemy creation
{
    public float Health;
    public float speed;
    public float damage;
    public Color color;
}
