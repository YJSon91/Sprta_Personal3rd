using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemSlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI quantityText;

    // 슬롯에 아이템 정보를 채워넣는 함수
    public void Set(InventorySlot slotData)
    {
        iconImage.sprite = slotData.item.itemIcon;
        iconImage.enabled = true; // 아이콘 이미지를 켭니다.
        quantityText.text = slotData.quantity > 1 ? slotData.quantity.ToString() : "";
    }

    // 슬롯을 비우는 함수
    public void Clear()
    {
        iconImage.sprite = null;
        iconImage.enabled = false; // 아이콘 이미지를 끕니다.
        quantityText.text = "";
    }
}