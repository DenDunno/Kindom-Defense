using UnityEngine;

public class TurretRotationToEnemy : IUpdatable
{
    private readonly TowerRadar _towerRadar;
    private readonly Transform _transform;
    private const float _maxAngle = 30;
    private const float _rotationToEnemySpeed = 8f;
    private const float _turnedToEnemyAngle = 5;
    
    public TurretRotationToEnemy(TowerRadar towerRadar, Transform transform)
    {
        _towerRadar = towerRadar;
        _transform = transform;
    }

    public bool TurnedToEnemy { get; private set; } = true;
    
    void IUpdatable.Update()
    {
        RotateToEnemy();
    }
    
    private void RotateToEnemy()
    {
        Quaternion rotation = Quaternion.LookRotation(_towerRadar.TargetEnemy.transform.position - _transform.position);

        if (rotation.eulerAngles.x > _maxAngle)
            rotation = Quaternion.Euler(_maxAngle, rotation.eulerAngles.y, 0);

        TurnedToEnemy = Mathf.Abs(rotation.eulerAngles.y - rotation.eulerAngles.y) < _turnedToEnemyAngle;
        
        _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, _rotationToEnemySpeed * Time.deltaTime);
    }
}