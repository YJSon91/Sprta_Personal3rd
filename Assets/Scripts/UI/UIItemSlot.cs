using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemSlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private GameObject equipMark; // ���� 'E' ��ũ ������Ʈ ���� �߰�

    private Character character;
    private InventorySlot currentSlotData;

    // ���Կ� ������ ������ ä���ִ� �Լ�
    // ���Կ� ������ ������ ä���ִ� �Լ��� �����մϴ�.
    public void Set(InventorySlot slotData, Character character)
    {
        this.currentSlotData = slotData;
        this.character = character;

        iconImage.sprite = slotData.item.itemIcon;
        iconImage.enabled = true;
        quantityText.text = slotData.quantity > 1 ? slotData.quantity.ToString() : "";

        // ���� ���� ���ο� ���� 'E' ��ũ�� �Ѱų� ���ϴ�. ����
        bool isEquipped = character.equippedItems.ContainsValue(slotData);
        equipMark.SetActive(isEquipped);
    }

    public void Clear()
    {
       
        equipMark.SetActive(false); // ��� ���� 'E' ��ũ�� ���ϴ�.
    }

    // ���� ������ Ŭ������ �� ȣ��� �Լ� �߰� ����
    public void OnSlotClick()
    {
        // 1. Ŭ���� ������ ����ְų�, ��� �������� �ƴϸ� �ƹ��͵� ���� �ʰ� �Լ��� �����մϴ�.
        if (currentSlotData == null || currentSlotData.item == null || currentSlotData.item.itemType != ItemType.Equipment)
        {
            return;
        }

        // 2. �� �������� ���� �����Ǿ� �ִ��� Ȯ���մϴ�.
        bool isEquipped = character.equippedItems.ContainsValue(currentSlotData);

        if (isEquipped)
        {
            // 3. �̹� �����Ǿ� �ִٸ� -> ���� ���� ������ �����մϴ�.
            // Unequip �Լ����� ����� ����(EquipmentType)�� �Ѱ��ݴϴ�.
            character.Unequip(currentSlotData.item.equipmentType);
        }
        else
        {
            // 4. �����Ǿ� ���� �ʴٸ� -> ���� ������ �����մϴ�.
            character.Equip(currentSlotData);
        }
    }
}