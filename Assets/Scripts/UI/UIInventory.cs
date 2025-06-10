using UnityEngine;

public class UIInventory : MonoBehaviour
{
    // ���� �����ϴ� ��ũ��Ʈ�� Ÿ�԰� ���� �̸��� �����մϴ�. ����
    private UIInventoryController uiInventoryController;

    private RectTransform rectTransform;
    private float onScreenX = 235f;
    private float offScreenX = 1850f;

    private void Awake()
    {
        // ���� ���⼭�� ����� �̸����� ������Ʈ�� �����ɴϴ�. ����
        uiInventoryController = GetComponent<UIInventoryController>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void Show()
    {
        // ���� ����� ���� �̸����� �Լ��� ȣ���մϴ�. ����
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