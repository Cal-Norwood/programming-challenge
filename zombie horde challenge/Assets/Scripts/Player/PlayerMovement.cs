using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 m_InMove;
    private Rigidbody2D m_RB;
    [SerializeField] private float m_MoveSpeed;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInMove(Vector2 move)
    {
        m_InMove = move.normalized;
    }

    private void FixedUpdate()
    {
        m_RB.linearVelocity = new Vector2(m_MoveSpeed * m_InMove.x, m_MoveSpeed * m_InMove.y);
    }
}
