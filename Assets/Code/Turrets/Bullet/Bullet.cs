using UnityEngine;

public abstract class Bullet : MonoBehaviour, IPoolableObject
{
    [SerializeField] private float _damage = 15;
    [SerializeField] private float _speed = 15f;

    public bool IsActive { get; private set; } = true;
    protected float Damage => _damage;
    protected float Speed => _speed;

    public abstract void Init(Transform target);
    
    void IPoolableObject.ResetObject()
    {
        ToggleBullet(true);
    }

    protected void ToggleBullet(bool activate)
    {
        IsActive = activate;
        gameObject.SetActive(activate);
    }
}