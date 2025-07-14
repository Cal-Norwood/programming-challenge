using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float m_MaxHealth;
    [SerializeField] private Image m_ProgressBar;
    private float m_CurrentHealth;

    private void Awake()
    {
        m_CurrentHealth = m_MaxHealth;
    }

    public void TakeDamage(float damage) // deal damage to player and check for death status
    {
        m_CurrentHealth -= damage;
        m_ProgressBar.fillAmount = m_CurrentHealth / m_MaxHealth;

        if(m_CurrentHealth <= 0)
        {
            Debug.Log("Dead");
        }
    }
}
