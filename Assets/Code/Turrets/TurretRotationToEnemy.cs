using UnityEngine;

public class TurretRotationToEnemy : IUpdatable
{
    private readonly TowerRadar _towerRadar;
    private readonly Transform _transform;
    private const float _maxAngle = 17;
    private const float _rotationToEnemySpeed = 8f;

    public TurretRotationToEnemy(TowerRadar towerRadar, Transform transform)
    {
        _towerRadar = towerRadar;
        _transform = transform;
    }
    
    void IUpdatable.Update()
    {
        RotateToEnemy();
    }
    
    private void RotateToEnemy()
    {
        Quaternion rotation = Quaternion.LookRotation(_towerRadar.ClosestEnemy.position - _transform.position);

        if (rotation.eulerAngles.x > _maxAngle)
            rotation = Quaternion.Euler(_maxAngle, rotation.eulerAngles.y, 0);

        _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, _rotationToEnemySpeed * Time.deltaTime);
    }
}