using UnityEngine;

// 아이템의 종류를 구분하기 위한 열거형(enum)
public enum ItemType
{
    Equipment,  // 장비
    Consumable, // 소모품
    Etc         // 기타
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
    // ▼▼▼ 아이템이 제공할 추가 능력치를 추가합니다. ▼▼▼
    public int attackBonus;
    public int defenseBonus;
    public int criticalBonus;
    public int healthBonus;
    public int expBonus;
}