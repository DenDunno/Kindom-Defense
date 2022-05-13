using System;
using BehaviorDesigner.Runtime;
using UnityEngine;

[Serializable]
public class EnemyRestart
{
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private Health _health;
    [SerializeField] private HealthBar _healthBar;
    private EnemyDissolve _enemyDissolve;
    private BehaviorTree _behaviorTree;

    public void Init(BehaviorTree behaviorTree)
    {
        _behaviorTree = behaviorTree;
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