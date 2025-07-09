using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputSystem_Actions IA;
    private PlayerMovement m_PM;

    private void Awake()
    {
        IA = new InputSystem_Actions();
        m_PM = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        IA.Enable();
        IA.Player.Move.performed += Handle_Move;
        IA.Player.Move.canceled += Handle_Move;
    }

    private void OnDisable()
    {
        IA.Disable();
        IA.Player.Move.performed -= Handle_Move;
        IA.Player.Move.canceled -= Handle_Move;
    }

    private void Handle_Move(InputAction.CallbackContext context)
    {
        m_PM.SetInMove(context.ReadValue<Vector2>());
    }
}
