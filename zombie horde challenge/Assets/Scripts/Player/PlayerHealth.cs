using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float m_MaxHealth;
    private float m_CurrentHealth;

    private void Awake()
    {
        m_CurrentHealth = m_MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        m_CurrentHealth -= damage;

        if(m_CurrentHealth <= 0)
        {
            Debug.Log("Dead");
        }
    }
}
