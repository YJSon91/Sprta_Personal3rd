using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // �ν����� â�� ���̰� �ϱ� ���� ��Ʈ����Ʈ
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
            // ������ ��� �����۵��� ��ȸ�ϸ� ���ʽ� ���� ���մϴ�.
            foreach (var slot in equippedItems.Values)
            {
                totalBonus += slot.item.attackBonus;
            }
            return baseAttack + totalBonus; // �⺻ ���ݷ� + ������ �߰� ���ݷ�
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
        set { health = Mathf.Clamp(value, 0, MaxHealth); } // �ִ� ü�� ���Ϸ� ����
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
            OnStatsChanged?.Invoke(); // ����ġ�� ����Ǿ����� �˸�
        }
    }
    public int Level
    {
        get { return level; }
        set
        {
            level = Mathf.Max(1, value); // ������ �ּ� 1�� ����
            OnStatsChanged?.Invoke(); // ������ ����Ǿ����� �˸�
        }
    }
    public int CurrentGold
    {
        get { return gold; }
        set
        {
            CurrentGold = Mathf.Max(0, value); // ���� ������ ���� �ʵ��� ����
            OnStatsChanged?.Invoke(); // ��尡 ����Ǿ����� �˸�
        }
    }
    public int MaxExp
    {
        get { return maxExp; }
        set { maxExp = Mathf.Max(100, value); } // �ּ� ����ġ�� 100���� ����
    }
    // ������ �Լ�   
    private void LevelUp()
    {
        level++;
        exp = 0; // ������ �� ����ġ �ʱ�ȭ
        maxExp += 500; // ���� �������� ���� ����ġ ���� (����)
        maxHealth += 20; // ������ �� �ִ� ü�� ���� (����)
        baseAttack += 5; // ������ �� ���ݷ� ���� (����)
        baseDefense += 3; // ������ �� ���� ���� (����)
        baseCritical += 2; // ������ �� ġ��Ÿ Ȯ�� ���� (����)
        Debug.Log($"������! ���� ����: {level}, �ִ� ü��: {MaxHealth}, ���ݷ�: {CurrentAttack}, ����: {CurrentDefense}, ġ��Ÿ Ȯ��: {CurrentCritical}%");
        OnStatsChanged?.Invoke(); // ������ ����Ǿ����� �˸�
    }

    [Header("Inventory")]
    // ���� �κ��丮 ����Ʈ�� �߰��մϴ�. ����
    public List<InventorySlot> inventory = new List<InventorySlot>();
    // ���� ������ �������� ������ Dictionary �߰� ����
    public Dictionary<EquipmentType, InventorySlot> equippedItems = new Dictionary<EquipmentType, InventorySlot>();


    // ���� UI ������ ���� �̺�Ʈ �߰� ����
    public event Action OnEquipmentChanged;
    public event Action OnStatsChanged; // ������ ����� �� �˸��� ���� �̺�Ʈ

    // ���� �������� �����ϴ� �Լ� �߰� ����
    public void Equip(InventorySlot slot)
    {
        // �̹� �ش� ������ �ٸ� �������� �����Ǿ� �ִٸ� ���� (�Ǵ� ��ü)
        if (equippedItems.ContainsKey(slot.item.equipmentType))
        {
            // ������ �����ϰ� ������ ������, ���߿��� ���⼭ ���� �������� �κ��丮�� ���������� ������ �ʿ��մϴ�.
        }

        equippedItems[slot.item.equipmentType] = slot;
        Debug.Log($"{slot.item.itemName}��(��) �����߽��ϴ�.");
        OnEquipmentChanged?.Invoke(); // ��� ���°� ����Ǿ����� �˸�
    }

    // ���� �������� ���� �����ϴ� �Լ� �߰�  ����
    public void Unequip(EquipmentType type)
    {
        if (equippedItems.ContainsKey(type))
        {
            // ���� ���� ����
            equippedItems.Remove(type);
            Debug.Log($"{type} ���� �������� �����߽��ϴ�.");
            OnEquipmentChanged?.Invoke();
        }
    }

    private void Awake()
    {
        health = maxHealth;
    }

    private void Start()
    {
        // Start �Լ��� ����ΰų� �ٸ� ������ ���� ���ܵӴϴ�.
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
    

    // ����: ����ġ�� ��� �Լ�
    public void AddExp(int amount)
    {
        exp += amount;
        // ... ������ ���� ...
        OnStatsChanged?.Invoke(); // ����ġ�� ����Ǿ����� �˸�
    }

    // ��带 ��� �Լ�
    public void AddGold(int amount)
    {
        CurrentGold += amount;
        OnStatsChanged?.Invoke(); // ��尡 ����Ǿ����� �˸�
    }
}