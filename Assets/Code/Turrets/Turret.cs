using UnityEngine;

public class Turret : Weapon
{
    [SerializeField] private WeaponRotation _weaponRotation;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private float _rate = 0.3f;
    private IFactory<Bullet> _bulletFactory;
    private float _clock;

    public void Init(IFactory<Bullet> bulletFactory)
    {
        _bulletFactory = bulletFactory;
    }

    protected override void UpdateWeapon(Transform targetEnemy)
    {
        if (_weaponRotation.ReadyForShooting)
        {
            if (Time.time > _rate + _clock)
            {
                _clock = Time.time;
                Shoot(targetEnemy.transform);
            }
        }
    }

    private void Shoot(Transform enemy)
    {
        Bullet bullet = _bulletFactory.Create();
        bullet.transform.position = _bulletSpawnPosition.position;
        bullet.SetTarget(enemy);
    }
}