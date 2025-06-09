using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 네임스페이스 추가

public class UIStatus : MonoBehaviour
{
    private RectTransform rectTransform;
    private float onScreenX = 235f;
    private float offScreenX = 1500f;

    // ▼▼▼ 인스펙터에서 연결할 TextMeshPro 변수들을 선언합니다. ▼▼▼
    
    [SerializeField] private TextMeshProUGUI hpText;    
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI criticalText;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // ▼▼▼ Character 데이터를 받아와서 UI를 업데이트하는 함수를 추가합니다. ▼▼▼
    public void UpdateStatusUI(Character character)
    {
        
        hpText.text = $"HP: {character.Health} / {character.MaxHealth}";       
        attackText.text = $"Atk: {character.CurrentAttack}";
        defenseText.text = $"Def: {character.CurrentDefense}";
        criticalText.text = $"Crt: {character.CurrentCritical}%";
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