using UnityEngine;

public abstract class Turret : Weapon
{
    [SerializeField] private WeaponRotation _weaponRotation;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _rate = 0.3f;
    private ObjectFactory<Bullet> _bulletFactory;
    private float _clock;

    private void Start()
    {
        _bulletFactory = new ObjectFactory<Bullet>(_bulletPrefab);
    }

    protected override void UpdateWeapon(Transform targetEnemy)
    {
        if (_weaponRotation.ReadyForShooting && ConditionForShooting)
        {
            if (Time.time > _rate + _clock)
            {
                _clock = Time.time;
                _bulletFactory.Update();
                Shoot(targetEnemy.transform);
            }
        }
    }

    private void Shoot(Transform enemy)
    {
        Bullet bullet = _bulletFactory.Create();
        bullet.transform.parent = transform;
        bullet.transform.position = _bulletSpawnPosition.position;
        bullet.Init(enemy);   
    }

    protected virtual bool ConditionForShooting => true;
}