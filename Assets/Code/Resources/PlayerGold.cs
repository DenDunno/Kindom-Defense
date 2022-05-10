using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerGold
{
    [SerializeField] private PlayerStatsUI _goldUI;
    [SerializeField] private int _gold;
    private readonly List<Enemy> _activeEnemies = new List<Enemy>();
    private readonly Dictionary<Health, int> _rewardForEnemy = new Dictionary<Health, int>();

    public int Value => _gold;
    
    public void Init()
    {
        SetGold(_gold);
    }
    
    public bool Buy(int price)
    {
        bool purchaseSuccessful = price <= _gold;

        if (purchaseSuccessful)
        {
            SetGold(_gold - price);
        }

        return purchaseSuccessful;
    }

    public void SoldWeapon(int weaponSellPrice)
    {
        SetGold(_gold + weaponSellPrice);
    }

    public void TryAddEnemyToTrack(Enemy enemy)
    {
        if (_activeEnemies.Contains(enemy) == false)
        {
            enemy.Health.Died += OnEnemyDied;
            _activeEnemies.Add(enemy);
            _rewardForEnemy[enemy.Health] = enemy.Stats.Reward;
        }
    }

    private void OnEnemyDied(Health enemy)
    {
        SetGold(_gold + _rewardForEnemy[enemy]);
    }

    private void SetGold(int gold)
    {
        _gold = gold;
        _goldUI.SetValue(gold);
    }
}