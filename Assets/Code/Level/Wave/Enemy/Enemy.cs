using UnityEngine;

public class Enemy : MonoBehaviour, IPoolableObject
{
    [SerializeField] public EnemyStartup _startup;
    [SerializeField] public EnemyRestart _restart;
    [SerializeField] private Health _health;
    [SerializeField] private int _reward = 3;
    
    public bool IsActive { get; private set; } = true;
    public EnemyStartup Startup => _startup;
    public Health Health => _health;
    public int Reward => _reward;

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
    }
}