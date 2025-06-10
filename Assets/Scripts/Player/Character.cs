using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // 인스펙터 창에 보이게 하기 위한 어트리뷰트
public class InventorySlot
{
    public ItemData item;
    public int quantity;
}
public class Character : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int maxExp = 1000;
    [SerializeField] private int level = 1;
    [SerializeField] private int exp = 0;
    [SerializeField] private int gold = 20000;
    [SerializeField] private int baseAttack = 35; 
    [SerializeField] private int baseDefense = 45; 
    [SerializeField] private int baseCritical = 25; 

    private int health;
    public event Action OnDie;

    public bool IsDie = false;

   
    public int MaxHealth
    {
        get
        {
            int totalBonus = 0;
            foreach (var slot in equippedItems.Values)
            {
                totalBonus += slot.item.healthBonus;
            }
            return maxHealth + totalBonus;
        }
    }

    public int CurrentAttack
    {
        get
        {
            int totalBonus = 0;
            // 장착된 모든 아이템들을 순회하며 보너스 값을 더합니다.
            foreach (var slot in equippedItems.Values)
            {
                totalBonus += slot.item.attackBonus;
            }
            return baseAttack + totalBonus; // 기본 공격력 + 아이템 추가 공격력
        }
    }

    public int CurrentDefense
    {
        get
        {
            int totalBonus = 0;
            foreach (var slot in equippedItems.Values)
            {
                totalBonus += slot.item.defenseBonus;
            }
            return baseDefense + totalBonus;
        }
    }
    public int CurrentCritical
    {
        get
        {
            int totalBonus = 0;
            foreach (var slot in equippedItems.Values)
            {
                totalBonus += slot.item.criticalBonus;
            }
            return baseCritical + totalBonus;
        }
    }
    public int Health
    {
        get { return health; }
        set { health = Mathf.Clamp(value, 0, MaxHealth); } // 최대 체력 이하로 제한
    }
    public int Exp
    {
        get { return exp; }
        set
        {
            exp = Mathf.Clamp(value, 0, maxExp);
            if (exp >= maxExp)
            {
                LevelUp();
            }
            OnStatsChanged?.Invoke(); // 경험치가 변경되었음을 알림
        }
    }
    public int Level
    {
        get { return level; }
        set
        {
            level = Mathf.Max(1, value); // 레벨은 최소 1로 제한
            OnStatsChanged?.Invoke(); // 레벨이 변경되었음을 알림
        }
    }
    public int CurrentGold
    {
        get { return gold; }
        set
        {
            CurrentGold = Mathf.Max(0, value); // 골드는 음수가 되지 않도록 제한
            OnStatsChanged?.Invoke(); // 골드가 변경되었음을 알림
        }
    }
    public int MaxExp
    {
        get { return maxExp; }
        set { maxExp = Mathf.Max(100, value); } // 최소 경험치는 100으로 제한
    }
    // 레벨업 함수   
    private void LevelUp()
    {
        level++;
        exp = 0; // 레벨업 시 경험치 초기화
        maxExp += 500; // 다음 레벨업을 위한 경험치 증가 (예시)
        maxHealth += 20; // 레벨업 시 최대 체력 증가 (예시)
        baseAttack += 5; // 레벨업 시 공격력 증가 (예시)
        baseDefense += 3; // 레벨업 시 방어력 증가 (예시)
        baseCritical += 2; // 레벨업 시 치명타 확률 증가 (예시)
        Debug.Log($"레벨업! 현재 레벨: {level}, 최대 체력: {MaxHealth}, 공격력: {CurrentAttack}, 방어력: {CurrentDefense}, 치명타 확률: {CurrentCritical}%");
        OnStatsChanged?.Invoke(); // 스탯이 변경되었음을 알림
    }

    [Header("Inventory")]
    // ▼▼▼ 인벤토리 리스트를 추가합니다. ▼▼▼
    public List<InventorySlot> inventory = new List<InventorySlot>();
    // ▼▼▼ 장착된 아이템을 저장할 Dictionary 추가 ▼▼▼
    public Dictionary<EquipmentType, InventorySlot> equippedItems = new Dictionary<EquipmentType, InventorySlot>();


    // ▼▼▼ UI 갱신을 위한 이벤트 추가 ▼▼▼
    public event Action OnEquipmentChanged;
    public event Action OnStatsChanged; // 스탯이 변경될 때 알림을 보낼 이벤트

    // ▼▼▼ 아이템을 장착하는 함수 추가 ▼▼▼
    public void Equip(InventorySlot slot)
    {
        // 이미 해당 부위에 다른 아이템이 장착되어 있다면 해제 (또는 교체)
        if (equippedItems.ContainsKey(slot.item.equipmentType))
        {
            // 지금은 간단하게 장착만 하지만, 나중에는 여기서 기존 아이템을 인벤토리로 돌려보내는 로직이 필요합니다.
        }

        equippedItems[slot.item.equipmentType] = slot;
        Debug.Log($"{slot.item.itemName}을(를) 장착했습니다.");
        OnEquipmentChanged?.Invoke(); // 장비 상태가 변경되었음을 알림
    }

    // ▼▼▼ 아이템을 장착 해제하는 함수 추가  ▼▼▼
    public void Unequip(EquipmentType type)
    {
        if (equippedItems.ContainsKey(type))
        {
            // 장착 해제 로직
            equippedItems.Remove(type);
            Debug.Log($"{type} 부위 아이템을 해제했습니다.");
            OnEquipmentChanged?.Invoke();
        }
    }

    private void Awake()
    {
        health = maxHealth;
    }

    private void Start()
    {
        // Start 함수는 비워두거나 다른 로직을 위해 남겨둡니다.
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        health = Mathf.Max(health - damage, 0);

        if (health == 0)
        {
            IsDie = true;
            OnDie?.Invoke();
        }

        Debug.Log(health);
    }
    

    // 예시: 경험치를 얻는 함수
    public void AddExp(int amount)
    {
        exp += amount;
        // ... 레벨업 로직 ...
        OnStatsChanged?.Invoke(); // 경험치가 변경되었음을 알림
    }

    // 골드를 얻는 함수
    public void AddGold(int amount)
    {
        CurrentGold += amount;
        OnStatsChanged?.Invoke(); // 골드가 변경되었음을 알림
    }
}