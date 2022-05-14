using UnityEngine;

public class MortarBullet : Bullet
{
    [SerializeField] private Particle _explosionPrefab;
    [SerializeField] private float _explosionRadius = 2f;
    private MortarBulletMovement _movement;
    private EnemyRadar _enemyRadar;
    private ObjectFactory<Particle> _explosionsFactory;

    private void Start()
    {
        _explosionsFactory = new ObjectFactory<Particle>(_explosionPrefab);
        _enemyRadar = new EnemyRadar(10, transform, _explosionRadius);
    }

    public override void Init()
    {
        _movement = new MortarBulletMovement(Target.position + Target.forward * 6, transform.position, Speed);
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
            ToggleBullet(false);
        }
    }

    private void DealDamage()
    {
        foreach (Health enemy in _enemyRadar.FindEnemies())
        {
            enemy.TakeDamage(Damage);
        }
    }

    private void Explode()
    {
        _explosionsFactory.Update();
        Particle explosion = _explosionsFactory.Create();
        explosion.transform.position = transform.position;
        explosion.Play();
    }
}