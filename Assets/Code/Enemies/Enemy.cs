using UnityEngine;

public class Enemy : MonoBehaviour, IPoolableObject
{
    [SerializeField] private EnemyStartup _startup;
    [SerializeField] private EnemyRestart _restart;
    [SerializeField] private Health _health;
    [SerializeField] private EnemyStats _enemyStats;
    
    public bool IsActive { get; private set; } = true;
    public EnemyStartup Startup => _startup;
    public Health Health => _health;
    public EnemyStats Stats => _enemyStats;

    private void Start()
    {
        _restart.Init();
    }

    void IPoolableObject.ResetObject()
    {
        IsActive = true;
        _restart.Execute();
    }

    public void MarkAsInactive()
    {
        IsActive = false;
        gameObject.SetActive(false);
    }
}