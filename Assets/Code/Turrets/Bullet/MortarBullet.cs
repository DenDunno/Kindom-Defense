using UnityEngine;

public class MortarBullet : Bullet
{
    [SerializeField] private float _explosionRadius = 2f;
    private MortarBulletMovement _movement;
    private EnemyRadar _enemyRadar;
    
    public override void Init()
    {
        _movement = new MortarBulletMovement(Target.position + Target.forward * 6, transform.position, Speed);
        _enemyRadar = new EnemyRadar(10, transform, _explosionRadius);
    }

    private void Update()
    {
        transform.position = _movement.EvaluatePosition();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other is TerrainCollider)
        {
            foreach (Health enemy in _enemyRadar.FindEnemies())
            {
                enemy.TakeDamage(Damage);
            }
            
            ToggleBullet(false);
        }
    }
}