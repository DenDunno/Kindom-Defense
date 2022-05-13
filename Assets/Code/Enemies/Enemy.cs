using BehaviorDesigner.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IPoolableObject
{
    [SerializeField] private EnemyStartup _startup;
    [SerializeField] private EnemyRestart _restart;
    [SerializeField] private Health _health;
    [SerializeField] private EnemyStats _enemyStats;
    [SerializeField] private BehaviorTree _behaviorTree;
    [SerializeField] private NavMeshAgent _agent;
    private bool _isInited;
    
    public bool IsActive { get; private set; } = true;
    public Health Health => _health;
    public EnemyStats Stats => _enemyStats;

    public void Init(Transform kingdom, Camera mainCamera)
    {
        if (_isInited == false)
        {
            _isInited = true;
            _startup.Init(kingdom, mainCamera, _behaviorTree);
            _restart.Init(_behaviorTree);
            EnableNavMeshAgent();
            _behaviorTree.enabled = true;
        }
    }

    void IPoolableObject.ResetObject()
    {
        IsActive = true;
        EnableNavMeshAgent();
        _restart.Execute();
    }

    public void MarkAsInactive()
    {
        IsActive = false;
        gameObject.SetActive(false);
        _agent.enabled = false;
    }

    private async void EnableNavMeshAgent()
    {
        await UniTask.Yield();
        _agent.enabled = true;
    }
}