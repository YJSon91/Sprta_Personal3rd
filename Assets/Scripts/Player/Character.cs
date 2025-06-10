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
    [SerializeField] private int Gold = 20000;
    [SerializeField] private int Attack = 35;
    [SerializeField] private int Defense = 45;
    [SerializeField] private int Critical = 25;

    private int health;
    public event Action OnDie;

    public bool IsDie = false;

    public int MaxHealth => maxHealth;
    public int MaxExp => maxExp;
    public int Level => level;
    public int Exp => exp;
    public int CurrentGold => Gold;
    public int CurrentAttack => Attack;
    public int CurrentDefense => Defense;
    public int CurrentCritical => Critical;
    public int Health => health;

    [Header("Inventory")]
    // ���� �κ��丮 ����Ʈ�� �߰��մϴ�. ����
    public List<InventorySlot> inventory = new List<InventorySlot>();
    private void Start()
    {
        health = maxHealth;
        
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
    public event Action OnStatsChanged; // ������ ����� �� �˸��� ���� �̺�Ʈ

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
        Gold += amount;
        OnStatsChanged?.Invoke(); // ��尡 ����Ǿ����� �˸�
    }
}