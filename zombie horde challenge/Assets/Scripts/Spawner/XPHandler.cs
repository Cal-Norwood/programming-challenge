using System;
using UnityEngine;

public class XPHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_RB;
    [SerializeField] private float m_SpawnForce;

    private void Awake() // XP fires off in a radom direction for effect
    {
        Vector2 randomDir = UnityEngine.Random.insideUnitCircle.normalized;
        m_RB.AddForce(randomDir * m_SpawnForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision) // collect xp
    {
        if(collision.TryGetComponent(out PlayerLevel PL))
        {
            PL.CollectXP();
        }
        Destroy(gameObject);
    }
}
