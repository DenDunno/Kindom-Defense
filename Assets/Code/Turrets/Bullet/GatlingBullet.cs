using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GatlingBullet : Bullet
{
    [SerializeField] private TrailRenderer _trail;
    private const float _timeBeforeEmitting = 0.005f;

    public async void Init()
    {
        Update();

        await UniTask.Delay(TimeSpan.FromSeconds(_timeBeforeEmitting));
        _trail.emitting = true;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        transform.LookAt(Target);
    }
    
    private void OnTriggerEnter(Collider enemy)
    {
        var enemyHealth = enemy.GetComponent<Health>();
        
        if (enemyHealth.IsDead == false || Target.transform == enemyHealth.transform)
        {
            enemyHealth.TakeDamage(Damage);

            MarkAsInactive();
            _trail.emitting = false;
        }
    }
}