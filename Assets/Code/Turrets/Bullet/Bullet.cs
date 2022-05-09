using UnityEngine;

public abstract class Bullet : MonoBehaviour, IPoolableObject
{
    [SerializeField] private float _damage = 15;
    [SerializeField] private float _speed = 15f;
    private Transform _target;
    
    public bool IsActive { get; private set; } = true;
    protected float Damage => _damage;
    protected float Speed => _speed;
    protected Transform Target => _target;
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
    void IPoolableObject.ResetObject()
    {
        ToggleBullet(true);
    }

    protected void ToggleBullet(bool activate)
    {
        IsActive = activate;
        gameObject.SetActive(activate);
    }

    public abstract void Init();
}