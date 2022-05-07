using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class PlayerGold
{
    [SerializeField] private TMP_Text _goldUI;
    private readonly List<Enemy> _activeEnemies = new List<Enemy>();
    private readonly Dictionary<Health, int> _rewardForEnemy = new Dictionary<Health, int>();
    private int _gold;

    public bool TryBuy(int price)
    {
        bool purchaseSuccessful = price <= _gold;

        if (purchaseSuccessful)
        {
            SetGold(_gold - price);
        }

        return purchaseSuccessful;
    }

    public void TryAddEnemyToTrack(Enemy enemy)
    {
        if (_activeEnemies.Contains(enemy) == false)
        {
            enemy.Health.Died += OnEnemyDied;
            _activeEnemies.Add(enemy);
            _rewardForEnemy[enemy.Health] = enemy.Reward;
        }
    }

    private void OnEnemyDied(Health enemy)
    {
        SetGold(_gold + _rewardForEnemy[enemy]);
    }

    private void SetGold(int gold)
    {
        _gold = gold;
        _goldUI.text = gold.ToString();
    }
}