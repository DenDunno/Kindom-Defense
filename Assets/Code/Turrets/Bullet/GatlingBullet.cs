using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GatlingBullet : Bullet
{
    [SerializeField] private TrailRenderer _trail;
    private Transform _target;
    private const float _timeBeforeEmitting = 0.005f;

    public override async void Init(Transform target)
    {
        _target = target;
        Update();

        await UniTask.Delay(TimeSpan.FromSeconds(_timeBeforeEmitting));
        _trail.emitting = true;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, Speed * Time.deltaTime);
        transform.LookAt(_target);
    }
    
    private void OnTriggerEnter(Collider enemy)
    {
        var enemyHealth = enemy.GetComponent<Health>();
        
        if (enemyHealth.IsDead == false || _target.transform == enemyHealth.transform)
        {
            enemyHealth.TakeDamage(Damage);

            ToggleBullet(false);   
            _trail.emitting = false;
        }
    }
}