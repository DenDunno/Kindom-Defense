using UnityEngine;

public class MortarBullet : Bullet
{
    [SerializeField] private float _explosionRadius = 2f;
    private MortarBulletMovement _movement;
    private EnemyRadar _enemyRadar;
    private IFactory<Particle> _explosionsFactory;
    private Particle _trail;
    
    public void Init(IFactory<Particle> explosionsPool, Particle trail)
    {
        _explosionsFactory = explosionsPool;
        _enemyRadar = new EnemyRadar(10, transform, _explosionRadius);
        _movement = new MortarBulletMovement(Target, transform.position, Stats.Speed);
        _movement.EvaluatePath();
        InitTrail(trail);
    }

    private void InitTrail(Particle trail)
    {
        _trail = trail;
        _trail.transform.position = transform.position;
        _trail.Play();
    }

    private void Update()
    {
        Vector3 position = _movement.EvaluatePosition();

        transform.position = position;
        _trail.transform.position = position;

        if (_movement.DestinationReached)
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