using UnityEngine;

// �������� ������ �����ϱ� ���� ������(enum)
public enum ItemType
{
    Equipment,  // ���
    Consumable, // �Ҹ�ǰ
    Etc         // ��Ÿ
}
public enum EquipmentType
{
    None,
    Weapon,
    Armor,
    Helmet,
    Boots
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/Item Data", order = 0)]
public class ItemData : ScriptableObject
{
    [Header("Item Info")]
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    public ItemType itemType;

    [Header("Equipment Info")]
    public EquipmentType equipmentType;

    [Header("Stat Bonuses")]
    // ���� �������� ������ �߰� �ɷ�ġ�� �߰��մϴ�. ����
    public int attackBonus;
    public int defenseBonus;
    public int criticalBonus;
    public int healthBonus;
    public int expBonus;
}