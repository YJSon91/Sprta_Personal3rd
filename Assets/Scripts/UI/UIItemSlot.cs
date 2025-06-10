using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemSlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI quantityText;

    // ���Կ� ������ ������ ä���ִ� �Լ�
    public void Set(InventorySlot slotData)
    {
        iconImage.sprite = slotData.item.itemIcon;
        iconImage.enabled = true; // ������ �̹����� �մϴ�.
        quantityText.text = slotData.quantity > 1 ? slotData.quantity.ToString() : "";
    }

    // ������ ���� �Լ�
    public void Clear()
    {
        iconImage.sprite = null;
        iconImage.enabled = false; // ������ �̹����� ���ϴ�.
        quantityText.text = "";
    }
}