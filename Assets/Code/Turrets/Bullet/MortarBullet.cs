using UnityEngine;

public class MortarBullet : Bullet
{
    [SerializeField] private float _explosionRadius = 2f;
    private MortarBulletMovement _movement;
    private EnemyRadar _enemyRadar;
    private IFactory<Particle> _explosionsFactory;

    public void Init(IFactory<Particle> explosionsFactory)
    {
        _explosionsFactory = explosionsFactory;
        _movement = new MortarBulletMovement(Target.position + Target.forward * 6, transform.position, Stats.Speed);
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
            DealDamage();
            Explode();
            MarkAsInactive();
        }
    }

    private void DealDamage()
    {
        foreach (Health enemy in _enemyRadar.FindEnemies())
        {
            enemy.TakeDamage(Stats.Damage);
        }
    }

    private void Explode()
    {
        Particle explosion = _explosionsFactory.Create();
        explosion.transform.position = transform.position;
        explosion.Play();
    }
}