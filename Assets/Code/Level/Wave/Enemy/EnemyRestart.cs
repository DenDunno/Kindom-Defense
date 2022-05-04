using System;
using BehaviorDesigner.Runtime;
using UnityEngine;

[Serializable]
public class EnemyRestart
{
    [SerializeField] private BehaviorTree _behaviorTree;
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private EnemyHealth _enemyHealth;
    private EnemyDissolve _enemyDissolve;
    
    public void Init()
    {
        _enemyDissolve = new EnemyDissolve(_renderers);
    }

    public void Execute()
    {
        _behaviorTree.OnBehaviorRestarted();
        _enemyHealth.ResetHealth();
        _enemyDissolve.SetDissolve(0);
    }
}