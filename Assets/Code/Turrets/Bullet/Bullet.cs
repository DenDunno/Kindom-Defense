using UnityEngine;

public class Bullet : PoolableObject
{
    [SerializeField] private BulletStats _bulletStats;

    protected BulletStats Stats => _bulletStats;
    protected Transform Target { get; private set; }

    public void SetTarget(Transform target)
    {
        Target = target;
    }
}