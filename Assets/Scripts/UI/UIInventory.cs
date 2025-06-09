// UIStatus.cs
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private RectTransform rectTransform;
    private float onScreenX = 235f;    // 화면에 보일 때의 X 좌표
    private float offScreenX = 1500f; // 화면 밖에 있을 때의 X 좌표 (값은 실제 캔버스 크기에 맞게 조절)

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Show()
    {
        // UIUtil을 통하는 대신, 자신의 RectTransform 위치를 직접 변경합니다.
        Vector2 newPosition = rectTransform.anchoredPosition;
        newPosition.x = onScreenX;
        rectTransform.anchoredPosition = newPosition;
    }

    public void Hide()
    {
        // UIUtil을 통하는 대신, 자신의 RectTransform 위치를 직접 변경합니다.
        Vector2 newPosition = rectTransform.anchoredPosition;
        newPosition.x = offScreenX;
        rectTransform.anchoredPosition = newPosition;
    }
}