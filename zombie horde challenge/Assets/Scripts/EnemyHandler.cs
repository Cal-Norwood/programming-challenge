using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private float m_MaxHealth;
    [SerializeField] private float m_CurrentHealth;
    [SerializeField] private float m_Speed;
    [SerializeField] private float m_Damage;
    [SerializeField] private Color m_Color;

    [SerializeField] private SpriteRenderer m_SR;

    public void Initialize(EnemyStatsSO stats)
    {
        m_MaxHealth = stats.Health;
        m_CurrentHealth = stats.Health;
        m_Speed = stats.speed;
        m_Damage = stats.damage;
        m_Color = stats.color;

        m_SR.color = m_Color;
    }
}
