using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 네임스페이스 추가

public class UIStatus : MonoBehaviour
{
    private RectTransform rectTransform;
    private float onScreenX = 545f;
    private float offScreenX = 1500f;

    // ▼▼▼ 인스펙터에서 연결할 TextMeshPro 변수들을 선언합니다. ▼▼▼
    
    [SerializeField] private TextMeshProUGUI hpText;    
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI criticalText;

    private Character character; // 캐릭터 참조를 저장할 변수


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        character = FindObjectOfType<Character>(); // 씬에서 캐릭터를 찾아 저장
    }
    // ▼▼▼ 스크립트가 활성화될 때 이벤트 구독 ▼▼▼
    private void OnEnable()
    {
        if (character != null)
        {
            character.OnEquipmentChanged += UpdateStatusUI;
        }
        // 스탯창이 켜질 때 현재 정보로 한번 업데이트
        UpdateStatusUI();
    }

    // ▼▼▼ 스크립트가 비활성화될 때 이벤트 구독 해제 ▼▼▼
    private void OnDisable()
    {
        if (character != null)
        {
            character.OnEquipmentChanged -= UpdateStatusUI;
        }
    }

    // UI를 업데이트하는 함수의 형태를 이벤트에 맞게 수정합니다.
    // 인자가 없는 형태로 만들고, 내부에서 character 변수를 사용합니다.
    public void UpdateStatusUI()
    {
        if (character == null) return;

       
        hpText.text = $"HP: {character.Health} / {character.MaxHealth}";
        attackText.text = $"Attack: {character.CurrentAttack}";
        defenseText.text = $"Defense: {character.CurrentDefense}";
        criticalText.text = $"Critical: {character.CurrentCritical}%";
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