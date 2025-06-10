using UnityEngine;

// �������� ������ �����ϱ� ���� ������(enum)
public enum ItemType
{
    Equipment,  // ���
    Consumable, // �Ҹ�ǰ
    Etc         // ��Ÿ
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