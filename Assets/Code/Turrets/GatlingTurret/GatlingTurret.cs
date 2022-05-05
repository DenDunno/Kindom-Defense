using UnityEngine;

public class GatlingTurret : MonoBehaviour
{
    [SerializeField] private GatlingBarrel _gatlingBarrel;
    [SerializeField] private TurretHead _turretHead;
    [SerializeField] private TowerRadar _towerRadar;
    [SerializeField] private Vector3 _bulletSpawnPosition;
    [SerializeField] private Bullet _bulletPrefab;
    private ObjectFactory<Bullet> _bulletFactory;
    private const float _rate = 0.3f;
    private float _clock;

    private void Start()
    {
        _bulletFactory = new ObjectFactory<Bullet>(_bulletPrefab);
    }

    private void Update()
    {
        if (_towerRadar.HasTarget && _gatlingBarrel.ReadyForShooting && _turretHead.ReadyForShooting)
        {
            if (Time.time > _rate + _clock)
            {
                _clock = Time.time;
                _bulletFactory.Update();
                SpawnBullet();
            }
        }
    }

    private void SpawnBullet()
    {
        Bullet bullet = _bulletFactory.Create();
        bullet.transform.parent = transform;
        bullet.transform.position = _gatlingBarrel.transform.TransformPoint(_bulletSpawnPosition);
        bullet.Init(_towerRadar.TargetEnemy.transform);   
    }
}