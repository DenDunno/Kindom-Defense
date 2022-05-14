using System;
using BehaviorDesigner.Runtime;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class EnemyRestart
{
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private Health _health;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private BehaviorTree _behaviorTree;
    [SerializeField] private NavMeshAgent _agent;
    private EnemyDissolve _enemyDissolve;

    public void Init()
    {
        _enemyDissolve = new EnemyDissolve(_renderers);
    }

    public void Execute()
    {
        _agent.Warp(_agent.transform.parent.position);
        _behaviorTree.OnBehaviorRestarted();
        _health.ResetHealth();
        _healthBar.ResetHealthBar();
        _enemyDissolve.SetDissolve(0);
    }
}