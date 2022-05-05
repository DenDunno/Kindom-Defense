using UnityEngine;

public class Enemy : MonoBehaviour, IPoolableObject
{
    [field: SerializeField] public EnemyStartup Startup { get; private set; }
    [SerializeField] public EnemyRestart _restart;

    public bool IsActive { get; private set; } = true;

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