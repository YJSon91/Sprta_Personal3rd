using UnityEngine;
using UnityEngine.UI;

public class UIXpBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Character character;

    // 스크립트가 활성화될 때 캐릭터의 이벤트에 우리 함수를 등록(구독)
    private void OnEnable()
    {
        if (character != null)
        {
            character.OnExpChanged += UpdateXpBar;
        }
        // 처음 켜질 때 현재 경험치로 한번 업데이트
        UpdateXpBar();
    }

    // 비활성화될 때 등록을 해제하여 메모리 누수 방지
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

        // 경험치를 비율(0~1)로 계산하여 fillAmount에 적용
        // (float) 캐스팅이 매우 중요합니다! (정수/정수 연산 방지)
        float fillAmount = (float)character.Exp / character.MaxExp;
        fillImage.fillAmount = fillAmount;
    }
}