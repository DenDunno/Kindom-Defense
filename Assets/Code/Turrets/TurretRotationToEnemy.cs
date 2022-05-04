using UnityEngine;

public class TurretRotationToEnemy : IUpdatable
{
    private readonly TowerRadar _towerRadar;
    private readonly Transform _transform;
    private const float _maxAngle = 50;
    private const float _rotationToEnemySpeed = 8f;
    private const float _turnedToEnemyDot = 0.95f;
    
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
        Quaternion rotation = Quaternion.LookRotation(_towerRadar.ClosestEnemy.transform.position - _transform.position);

        // if (rotation.eulerAngles.x > _maxAngle)
        //     rotation = Quaternion.Euler(_maxAngle, rotation.eulerAngles.y, 0);

        TurnedToEnemy = Mathf.Abs(Quaternion.Dot(_transform.rotation, rotation)) >= _turnedToEnemyDot;
        
        _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, _rotationToEnemySpeed * Time.deltaTime);
    }
}