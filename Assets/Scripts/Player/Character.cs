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
    // ▼▼▼ 인벤토리 리스트를 추가합니다. ▼▼▼
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
    public event Action OnStatsChanged; // 스탯이 변경될 때 알림을 보낼 이벤트

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
        Gold += amount;
        OnStatsChanged?.Invoke(); // 골드가 변경되었음을 알림
    }
}