using UnityEngine;

public abstract class Turret : Weapon
{
    [SerializeField] private WeaponRotation _weaponRotation;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private float _rate = 0.3f;
    private IFactory<Bullet> _bulletPool;
    private IBulletInitialization _bulletInitialization;
    private float _clock;

    public void Init(IFactory<Bullet> bulletPool, IBulletInitialization bulletInitialization)
    {
        _bulletPool = bulletPool;
        _bulletInitialization = bulletInitialization;
    }

    protected override void UpdateWeapon(Transform targetEnemy)
    {
        if (_weaponRotation.ReadyForShooting)
        {
            if (Time.time > _rate + _clock)
            {
                _clock = Time.time;
                Shoot(targetEnemy);
            }
        }
    }

    private void Shoot(Transform target)
    {
        Bullet bullet = _bulletPool.Create();
        bullet.transform.position = _bulletSpawnPosition.position;
        bullet.SetTarget(target);
        _bulletInitialization.Execute(bullet);
    }
}