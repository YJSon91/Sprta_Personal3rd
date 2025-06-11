using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 네임스페이스 추가

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI nickNameText;
    [SerializeField] private TextMeshProUGUI charClassText;

    private Character character;
    // Status 버튼에 연결할 함수
    private void Start()
    {
        character = FindObjectOfType<Character>();
        if (character == null) return;

        // character의 스탯 변경 이벤트를 구독합니다.
        character.OnStatsChanged += UpdateUI;

        // 처음 한 번 UI를 초기화합니다.
        UpdateUI();
    }

    // FixedUpdate는 이제 필요 없으므로 삭제합니다.

    // UI를 업데이트하는 함수
    private void UpdateUI()
    {
        if (character == null) return;
        expText.text = $"EXP: {character.Exp} / {character.MaxExp}";
        goldText.text = $"{character.CurrentGold}";
        levelText.text = $"LV: {character.Level}";
        nickNameText.text = character.NickName;
        charClassText.text = character.CharClass;
    }

    private void OnDestroy()
    {
        // 오브젝트가 파괴될 때 구독을 해제하여 메모리 누수를 방지합니다.
        if (character != null)
        {
            character.OnStatsChanged -= UpdateUI;
        }
    }
    public void OnClickStatusButton()
    {
        UIManager.Instance.ShowStatusUI();
    }

    // Inventory 버튼에 연결할 함수
    public void OnClickInventoryButton()
    {
        UIManager.Instance.ShowInventoryUI();
    }

    // Back 버튼에 연결할 함수
    public void OnClickBackButton()
    {
        UIManager.Instance.CloseAllPanels();
    }

}