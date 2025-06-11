using UnityEngine;
using UnityEngine.UI;

public class UIXpBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Character character;

    // ��ũ��Ʈ�� Ȱ��ȭ�� �� ĳ������ �̺�Ʈ�� �츮 �Լ��� ���(����)
    private void OnEnable()
    {
        if (character != null)
        {
            character.OnExpChanged += UpdateXpBar;
        }
        // ó�� ���� �� ���� ����ġ�� �ѹ� ������Ʈ
        UpdateXpBar();
    }

    // ��Ȱ��ȭ�� �� ����� �����Ͽ� �޸� ���� ����
    private void OnDisable()
    {
        if (character != null)
        {
            character.OnExpChanged -= UpdateXpBar;
        }
    }

    private void UpdateXpBar()
    {
        if (character == null) return;

        // ����ġ�� ����(0~1)�� ����Ͽ� fillAmount�� ����
        // (float) ĳ������ �ſ� �߿��մϴ�! (����/���� ���� ����)
        float fillAmount = (float)character.Exp / character.MaxExp;
        fillImage.fillAmount = fillAmount;
    }
}