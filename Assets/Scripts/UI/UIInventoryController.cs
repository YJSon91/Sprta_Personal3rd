using UnityEngine;

public class UIInventoryController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Character character;
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform contentArea;

    [Header("Settings")]
    [SerializeField] private int slotCount = 9; // 표시할 슬롯의 총 개수

    public void Redraw()
    {
        // 1. 기존 슬롯들 삭제
        foreach (Transform child in contentArea)
        {
            Destroy(child.gameObject);
        }

        // 2. 정해진 개수(9개)만큼 슬롯을 생성하는 반복문
        for (int i = 0; i < slotCount; i++)
        {
            // 슬롯 프리팹 생성하고 UIItemSlot 컴포넌트 가져오기
            GameObject newSlotObj = Instantiate(itemSlotPrefab, contentArea);
            UIItemSlot newSlotUI = newSlotObj.GetComponent<UIItemSlot>();

            // 3. 현재 인덱스(i)에 해당하는 아이템 데이터가 있는지 확인
            if (i < character.inventory.Count)
            {
                // 아이템이 있다면, 슬롯에 정보를 채우도록 명령
                newSlotUI.Set(character.inventory[i]);
            }
            else
            {
                // 해당하는 아이템이 없다면, 빈 슬롯으로 보이도록 명령
                newSlotUI.Clear();
            }
        }
    }
}