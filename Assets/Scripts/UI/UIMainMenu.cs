using UnityEngine;
using TMPro; // TextMeshPro�� ����ϱ� ���� ���ӽ����̽� �߰�

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI nickNameText;
    [SerializeField] private TextMeshProUGUI charClassText;

    private Character character;
    // Status ��ư�� ������ �Լ�
    private void Start()
    {
        character = FindObjectOfType<Character>();
        if (character == null) return;

        // character�� ���� ���� �̺�Ʈ�� �����մϴ�.
        character.OnStatsChanged += UpdateUI;

        // ó�� �� �� UI�� �ʱ�ȭ�մϴ�.
        UpdateUI();
    }

    // FixedUpdate�� ���� �ʿ� �����Ƿ� �����մϴ�.

    // UI�� ������Ʈ�ϴ� �Լ�
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
        // ������Ʈ�� �ı��� �� ������ �����Ͽ� �޸� ������ �����մϴ�.
        if (character != null)
        {
            character.OnStatsChanged -= UpdateUI;
        }
    }
    public void OnClickStatusButton()
    {
        UIManager.Instance.ShowStatusUI();
    }

    // Inventory ��ư�� ������ �Լ�
    public void OnClickInventoryButton()
    {
        UIManager.Instance.ShowInventoryUI();
    }

    // Back ��ư�� ������ �Լ�
    public void OnClickBackButton()
    {
        UIManager.Instance.CloseAllPanels();
    }

}