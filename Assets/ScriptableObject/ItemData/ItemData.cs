using UnityEngine;

// 아이템의 종류를 구분하기 위한 열거형(enum)
public enum ItemType
{
    Equipment,  // 장비
    Consumable, // 소모품
    Etc         // 기타
}


[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/Item Data", order = 0)]
public class ItemData : ScriptableObject
{
    [Header("Item Info")]
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    public ItemType itemType;
}