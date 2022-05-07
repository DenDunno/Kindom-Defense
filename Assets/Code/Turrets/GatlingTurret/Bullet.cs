using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolableObject
{
    [SerializeField] private float _damage = 15;
    [SerializeField] private TrailRenderer _trail;
    private Transform _target;
    private const float _timeBeforeEmitting = 0.005f;
    private const float _speed = 15f;

    public bool IsActive { get; private set; } = true;

    public async void Init(Transform target)
    {
        _target = target;
        Update();

        await UniTask.Delay(TimeSpan.FromSeconds(_timeBeforeEmitting));
        _trail.emitting = true;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.LookAt(_target);
    }

    private void OnTriggerEnter(Collider enemy)
    {
        var enemyHealth = enemy.GetComponent<Health>();
        
        if (enemyHealth.IsDead == false || _target.transform == enemyHealth.transform)
        {
            enemyHealth.TakeDamage(_damage);

            ToggleBullet(false);   
            _trail.emitting = false;
        }
    }

    void IPoolableObject.ResetObject()
    {
        ToggleBullet(true);
    }

    private void ToggleBullet(bool activate)
    {
        IsActive = activate;
        gameObject.SetActive(activate);
    }
}