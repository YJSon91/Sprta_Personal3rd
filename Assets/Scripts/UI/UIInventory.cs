using UnityEngine;

public class UIInventory : MonoBehaviour
{
    // ▼▼▼ 참조하는 스크립트의 타입과 변수 이름을 변경합니다. ▼▼▼
    private UIInventoryController uiInventoryController;

    private RectTransform rectTransform;
    private float onScreenX = 235f;
    private float offScreenX = 1850f;

    private void Awake()
    {
        // ▼▼▼ 여기서도 변경된 이름으로 컴포넌트를 가져옵니다. ▼▼▼
        uiInventoryController = GetComponent<UIInventoryController>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void Show()
    {
        // ▼▼▼ 변경된 변수 이름으로 함수를 호출합니다. ▼▼▼
        if (uiInventoryController != null)
        {
            uiInventoryController.Redraw();
        }

        Vector2 newPosition = rectTransform.anchoredPosition;
        newPosition.x = onScreenX;
        rectTransform.anchoredPosition = newPosition;
    }

    public void Hide()
    {
        Vector2 newPosition = rectTransform.anchoredPosition;
        newPosition.x = offScreenX;
        rectTransform.anchoredPosition = newPosition;
    }
}