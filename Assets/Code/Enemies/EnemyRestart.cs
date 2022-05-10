using System;
using BehaviorDesigner.Runtime;
using UnityEngine;

[Serializable]
public class EnemyRestart
{
    [SerializeField] private BehaviorTree _behaviorTree;
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private Health _health;
    [SerializeField] private HealthBar _healthBar;
    private EnemyDissolve _enemyDissolve;
    
    public void Init()
    {
        _enemyDissolve = new EnemyDissolve(_renderers);
    }

    public void Execute()
    {
        _behaviorTree.OnBehaviorRestarted();
        _health.ResetHealth();
        _healthBar.ResetHealthBar();
        _enemyDissolve.SetDissolve(0);
    }
}