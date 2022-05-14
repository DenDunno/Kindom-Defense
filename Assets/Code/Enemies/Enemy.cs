using UnityEngine;

public class Enemy : MonoBehaviour, IPoolableObject
{
    [SerializeField] private EnemyStartup _startup;
    [SerializeField] private EnemyRestart _restart;
    [SerializeField] private EnemyStats _enemyStats;
    [SerializeField] private Health _health;
    private bool _isInited;
    
    public bool IsActive { get; private set; } = true;
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
            ResetObject();
        }
    }

    public void ResetObject()
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