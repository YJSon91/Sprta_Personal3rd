using UnityEngine;
using TMPro; // TextMeshPro�� ����ϱ� ���� ���ӽ����̽� �߰�

public class UIStatus : MonoBehaviour
{
    private RectTransform rectTransform;
    private float onScreenX = 545f;
    private float offScreenX = 1500f;

    // ���� �ν����Ϳ��� ������ TextMeshPro �������� �����մϴ�. ����
    
    [SerializeField] private TextMeshProUGUI hpText;    
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI criticalText;

    private Character character; // ĳ���� ������ ������ ����


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        character = FindObjectOfType<Character>(); // ������ ĳ���͸� ã�� ����
    }
    // ���� ��ũ��Ʈ�� Ȱ��ȭ�� �� �̺�Ʈ ���� ����
    private void OnEnable()
    {
        if (character != null)
        {
            character.OnEquipmentChanged += UpdateStatusUI;
        }
        // ����â�� ���� �� ���� ������ �ѹ� ������Ʈ
        UpdateStatusUI();
    }

    // ���� ��ũ��Ʈ�� ��Ȱ��ȭ�� �� �̺�Ʈ ���� ���� ����
    private void OnDisable()
    {
        if (character != null)
        {
            character.OnEquipmentChanged -= UpdateStatusUI;
        }
    }

    // UI�� ������Ʈ�ϴ� �Լ��� ���¸� �̺�Ʈ�� �°� �����մϴ�.
    // ���ڰ� ���� ���·� �����, ���ο��� character ������ ����մϴ�.
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