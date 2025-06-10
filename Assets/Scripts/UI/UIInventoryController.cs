using UnityEngine;

public class UIInventoryController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Character character;
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform contentArea;

    [Header("Settings")]
    [SerializeField] private int slotCount = 12 ;

    public void Redraw()
    {
        // 1. ���� ���Ե� ����
        foreach (Transform child in contentArea)
        {
            Destroy(child.gameObject);
        }

        // 2. ������ ������ŭ ������ �����ϴ� �ݺ���
        for (int i = 0; i < slotCount; i++)
        {
            
            // ���� �������� ������ �����ϰ�,
            GameObject newSlotObj = Instantiate(itemSlotPrefab, contentArea);
            // ������ ���� ������Ʈ���� UIItemSlot ��ũ��Ʈ�� �����ɴϴ�.
            UIItemSlot newSlotUI = newSlotObj.GetComponent<UIItemSlot>();
           
            // 3. ���� �ε����� �ش��ϴ� ������ �����Ͱ� �ִ��� Ȯ��
            if (i < character.inventory.Count)
            {
                // �������� �ִٸ�, ���Կ� ������ ä�쵵�� ���
                newSlotUI.Set(character.inventory[i], character);
            }
            else
            {
                // �ش��ϴ� �������� ���ٸ�, �� �������� ���̵��� ���
                newSlotUI.Clear();
            }
        }
    }

    private void OnEnable()
    {
        // OnEnable/OnDisable �κ��� ���� �� �ۼ��ϼ̽��ϴ�.
        if (character != null)
        {
            character.OnEquipmentChanged += Redraw;
        }
    }

    private void OnDisable()
    {
        if (character != null)
        {
            character.OnEquipmentChanged -= Redraw;
        }
    }
}