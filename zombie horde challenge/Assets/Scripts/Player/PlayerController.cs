using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputSystem_Actions IA;
    private PlayerMovement m_PM;
    private WeaponHandler m_WH;

    private void Awake()
    {
        IA = new InputSystem_Actions();
        m_PM = GetComponent<PlayerMovement>();
        m_WH = GetComponent<WeaponHandler>();
    }

    private void OnEnable() //bind inputs to functions
    {
        IA.Enable();
        IA.Player.Move.performed += Handle_Move;
        IA.Player.Move.canceled += Handle_Move;
        IA.Player.Attack.performed += Handle_Attack_Performed;
        IA.Player.Attack.canceled += Handle_Attack_Canceled;
    }

    private void OnDisable()
    {
        IA.Disable();
        IA.Player.Move.performed -= Handle_Move;
        IA.Player.Move.canceled -= Handle_Move;
        IA.Player.Attack.performed -= Handle_Attack_Performed;
        IA.Player.Attack.canceled -= Handle_Attack_Canceled;
    }

    private void Handle_Move(InputAction.CallbackContext context)
    {
        m_PM?.SetInMove(context.ReadValue<Vector2>());
    }

    private void Handle_Attack_Performed(InputAction.CallbackContext context)
    {
        m_WH?.Fire();
    }

    private void Handle_Attack_Canceled(InputAction.CallbackContext context)
    {
        m_WH?.StopFire();
    }
}
