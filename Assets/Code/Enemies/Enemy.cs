using UnityEngine;

public class Enemy : PoolableObject
{
    [SerializeField] private EnemyStartup _startup;
    [SerializeField] private EnemyRestart _restart;
    [SerializeField] private EnemyStats _enemyStats;
    [SerializeField] private Health _health;
    private bool _isInited;
    
    public Health Health => _health;
    public EnemyStats Stats => _enemyStats;

    public void Init(Transform kingdom, Camera mainCamera)
    {
        if (_isInited == false)
        {
            _isInited = true;
            _health.Init();
            _startup.Init(kingdom, mainCamera);
            _restart.Init();
            _restart.Execute();
        }
    }

    protected override void OnReset()
    {
        _restart.Execute();
    }
}