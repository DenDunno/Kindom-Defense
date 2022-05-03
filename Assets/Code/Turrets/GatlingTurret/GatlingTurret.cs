using UnityEngine;

public class GatlingTurret : MonoBehaviour
{
    [SerializeField] private GatlingTurretSpinning _spinning;
    [SerializeField] private TowerRadar _towerRadar;
    [SerializeField] private Vector3 _bulletSpawnPosition;
    [SerializeField] private Bullet _bulletPrefab;
    private const float _rate = 0.5f;
    private float _clock;
    private ObjectFactory<Bullet> _bulletFactory;

    private void Start()
    {
        _bulletFactory = new ObjectFactory<Bullet>(_bulletPrefab);
    }

    private void Update()
    {
        if (_towerRadar.HasTarget && _spinning.ReadyForShooting)
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
        bullet.transform.position = _spinning.transform.TransformPoint(_bulletSpawnPosition);
        bullet.Init(_towerRadar.ClosestEnemy);   
    }
}