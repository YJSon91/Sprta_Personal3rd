using UnityEngine;
using UnityEngine.InputSystem; // Input System 네임스페이스 추가

public class InputTest : MonoBehaviour
{
    private PlayerInputs playerInputs; // 여러분의 Input Action 클래스 이름으로 변경
    private InputAction movementAction;

    void Awake()
    {
        playerInputs = new PlayerInputs(); // Input Action 클래스 인스턴스화

        // "Player" Action Map의 "Movement" Action 가져오기 시도
        // 방법 1: 직접 Action 찾기 (더 안정적일 수 있음)
        movementAction = playerInputs.asset.FindActionMap("Player").FindAction("Movement");

        // 방법 2: 생성된 프로퍼티 사용 (기존 방식)
        // movementAction = playerInputs.Player.Movement;

        if (movementAction == null)
        {
            Debug.LogError("Movement Action을 찾을 수 없습니다!");
        }
        else
        {
            Debug.Log("Movement Action을 성공적으로 찾았습니다.");
        }
    }

    void OnEnable()
    {
        if (movementAction != null)
        {
            movementAction.Enable();
            movementAction.performed += OnMovementPerformed;
            movementAction.canceled += OnMovementCanceled;
            Debug.Log("Movement Action 활성화 및 콜백 등록됨.");
        }
    }

    void OnDisable()
    {
        if (movementAction != null)
        {
            movementAction.Disable();
            movementAction.performed -= OnMovementPerformed;
            movementAction.canceled -= OnMovementCanceled;
            Debug.Log("Movement Action 비활성화 및 콜백 해제됨.");
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