using System.Collections;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_RB;
    [SerializeField] private float m_BulletSpeed;
    public float m_Damage;

    private void Start()
    {
        m_RB.AddForce(transform.up * m_BulletSpeed, ForceMode2D.Impulse);
        StartCoroutine(DeathTimer());
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyHandler EH))
        {
            EH.TakeDamage(m_Damage);

            Destroy(gameObject);
        }
    }
}
