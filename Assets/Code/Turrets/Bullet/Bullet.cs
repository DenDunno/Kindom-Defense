using UnityEngine;

public class Bullet : PoolableObject
{
    [SerializeField] private float _damage = 15;
    [SerializeField] private float _speed = 15f;
    private Transform _target;
    
    protected float Damage => _damage;
    protected float Speed => _speed;
    protected Transform Target => _target;
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }
}