using UnityEngine;
using UnityEngine.InputSystem; // Input System ���ӽ����̽� �߰�

public class InputTest : MonoBehaviour
{
    private PlayerInputs playerInputs; // �������� Input Action Ŭ���� �̸����� ����
    private InputAction movementAction;

    void Awake()
    {
        playerInputs = new PlayerInputs(); // Input Action Ŭ���� �ν��Ͻ�ȭ

        // "Player" Action Map�� "Movement" Action �������� �õ�
        // ��� 1: ���� Action ã�� (�� �������� �� ����)
        movementAction = playerInputs.asset.FindActionMap("Player").FindAction("Movement");

        // ��� 2: ������ ������Ƽ ��� (���� ���)
        // movementAction = playerInputs.Player.Movement;

        if (movementAction == null)
        {
            Debug.LogError("Movement Action�� ã�� �� �����ϴ�!");
        }
        else
        {
            Debug.Log("Movement Action�� ���������� ã�ҽ��ϴ�.");
        }
    }

    void OnEnable()
    {
        if (movementAction != null)
        {
            movementAction.Enable();
            movementAction.performed += OnMovementPerformed;
            movementAction.canceled += OnMovementCanceled;
            Debug.Log("Movement Action Ȱ��ȭ �� �ݹ� ��ϵ�.");
        }
    }

    void OnDisable()
    {
        if (movementAction != null)
        {
            movementAction.Disable();
            movementAction.performed -= OnMovementPerformed;
            movementAction.canceled -= OnMovementCanceled;
            Debug.Log("Movement Action ��Ȱ��ȭ �� �ݹ� ������.");
        }
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        Vector2 moveVector = context.ReadValue<Vector2>();
        Debug.Log("Movement Performed: " + moveVector);
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("Movement Canceled");
    }

    void Update()
    {
        if (movementAction != null && movementAction.enabled)
        {
            // Vector2 moveInput = movementAction.ReadValue<Vector2>();
            // if (moveInput != Vector2.zero)
            // {
            //     Debug.Log("Movement Input: " + moveInput);
            // }
        }
    }
}