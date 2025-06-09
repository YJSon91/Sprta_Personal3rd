using UnityEngine;
using TMPro; // TextMeshPro�� ����ϱ� ���� ���ӽ����̽� �߰�

public class UIStatus : MonoBehaviour
{
    private RectTransform rectTransform;
    private float onScreenX = 235f;
    private float offScreenX = 1500f;

    // ���� �ν����Ϳ��� ������ TextMeshPro �������� �����մϴ�. ����
    
    [SerializeField] private TextMeshProUGUI hpText;    
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI criticalText;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // ���� Character �����͸� �޾ƿͼ� UI�� ������Ʈ�ϴ� �Լ��� �߰��մϴ�. ����
    public void UpdateStatusUI(Character character)
    {
        
        hpText.text = $"HP: {character.Health} / {character.MaxHealth}";       
        attackText.text = $"Atk: {character.CurrentAttack}";
        defenseText.text = $"Def: {character.CurrentDefense}";
        criticalText.text = $"Crt: {character.CurrentCritical}%";
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