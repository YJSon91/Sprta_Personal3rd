// UIStatus.cs
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private RectTransform rectTransform;
    private float onScreenX = 235f;    // ȭ�鿡 ���� ���� X ��ǥ
    private float offScreenX = 1500f; // ȭ�� �ۿ� ���� ���� X ��ǥ (���� ���� ĵ���� ũ�⿡ �°� ����)

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Show()
    {
        // UIUtil�� ���ϴ� ���, �ڽ��� RectTransform ��ġ�� ���� �����մϴ�.
        Vector2 newPosition = rectTransform.anchoredPosition;
        newPosition.x = onScreenX;
        rectTransform.anchoredPosition = newPosition;
    }

    public void Hide()
    {
        // UIUtil�� ���ϴ� ���, �ڽ��� RectTransform ��ġ�� ���� �����մϴ�.
        Vector2 newPosition = rectTransform.anchoredPosition;
        newPosition.x = offScreenX;
        rectTransform.anchoredPosition = newPosition;
    }
}