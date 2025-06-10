using UnityEngine;

public class UIInventoryController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Character character;
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform contentArea;

    [Header("Settings")]
    [SerializeField] private int slotCount = 9; // ǥ���� ������ �� ����

    public void Redraw()
    {
        // 1. ���� ���Ե� ����
        foreach (Transform child in contentArea)
        {
            Destroy(child.gameObject);
        }

        // 2. ������ ����(9��)��ŭ ������ �����ϴ� �ݺ���
        for (int i = 0; i < slotCount; i++)
        {
            // ���� ������ �����ϰ� UIItemSlot ������Ʈ ��������
            GameObject newSlotObj = Instantiate(itemSlotPrefab, contentArea);
            UIItemSlot newSlotUI = newSlotObj.GetComponent<UIItemSlot>();

            // 3. ���� �ε���(i)�� �ش��ϴ� ������ �����Ͱ� �ִ��� Ȯ��
            if (i < character.inventory.Count)
            {
                // �������� �ִٸ�, ���Կ� ������ ä�쵵�� ���
                newSlotUI.Set(character.inventory[i]);
            }
            else
            {
                // �ش��ϴ� �������� ���ٸ�, �� �������� ���̵��� ���
                newSlotUI.Clear();
            }
        }
    }
}