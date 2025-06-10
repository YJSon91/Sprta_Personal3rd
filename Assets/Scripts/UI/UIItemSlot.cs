using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemSlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private GameObject equipMark; // ▼▼▼ 'E' 마크 오브젝트 참조 추가

    private Character character;
    private InventorySlot currentSlotData;

    // 슬롯에 아이템 정보를 채워넣는 함수
    // 슬롯에 아이템 정보를 채워넣는 함수를 수정합니다.
    public void Set(InventorySlot slotData, Character character)
    {
        this.currentSlotData = slotData;
        this.character = character;

        iconImage.sprite = slotData.item.itemIcon;
        iconImage.enabled = true;
        quantityText.text = slotData.quantity > 1 ? slotData.quantity.ToString() : "";

        // ▼▼▼ 장착 여부에 따라 'E' 마크를 켜거나 끕니다. ▼▼▼
        bool isEquipped = character.equippedItems.ContainsValue(slotData);
        equipMark.SetActive(isEquipped);
    }

    public void Clear()
    {
       
        equipMark.SetActive(false); // 비울 때도 'E' 마크를 끕니다.
    }

    // ▼▼▼ 슬롯을 클릭했을 때 호출될 함수 추가 ▼▼▼
    public void OnSlotClick()
    {
        // 1. 클릭한 슬롯이 비어있거나, 장비 아이템이 아니면 아무것도 하지 않고 함수를 종료합니다.
        if (currentSlotData == null || currentSlotData.item == null || currentSlotData.item.itemType != ItemType.Equipment)
        {
            return;
        }

        // 2. 이 아이템이 현재 장착되어 있는지 확인합니다.
        bool isEquipped = character.equippedItems.ContainsValue(currentSlotData);

        if (isEquipped)
        {
            // 3. 이미 장착되어 있다면 -> 장착 해제 로직을 실행합니다.
            // Unequip 함수에는 장비의 부위(EquipmentType)를 넘겨줍니다.
            character.Unequip(currentSlotData.item.equipmentType);
        }
        else
        {
            // 4. 장착되어 있지 않다면 -> 장착 로직을 실행합니다.
            character.Equip(currentSlotData);
        }
    }
}