using UnityEngine;
using System;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] protected EnemyStatsSO m_EnemyData;

    [SerializeField] private SpriteRenderer m_SR;

    [SerializeField] private GameObject m_Player;

    private float m_CurrentHealth;

    public Action<int, Vector3> EnemyDead;

    private void Awake()
    {
        m_Player = GameObject.Find("Player");
    }

    public virtual void Initialize(EnemyStatsSO stats)
    {
        m_EnemyData = stats;

        m_SR.color = stats.color;

        m_CurrentHealth = m_EnemyData.Health;
    }

    public void TakeDamage(float damage)
    {
        m_CurrentHealth -= damage;

        if(m_CurrentHealth <= 0)
        {
            EnemyDead?.Invoke(1, transform.position);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (m_Player == null) return;

        Vector3 direction = (m_Player.transform.position - transform.position).normalized;
        transform.position += direction * m_EnemyData.speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerHealth PH))
        {
            EnemyDead?.Invoke(0, transform.position);
            PH.TakeDamage(m_EnemyData.damage);
            Destroy(gameObject);
        }
    }
}
