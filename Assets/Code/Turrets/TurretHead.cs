using UnityEngine;

public class TurretHead : MonoBehaviour
{
    [SerializeField] private TowerRadar _towerRadar;
    private TurretRotationToEnemy _rotationToEnemy;
    private TurretIdleAnimation _idleAnimation;

    public bool ReadyForShooting => _rotationToEnemy.TurnedToEnemy;
    
    private void Start()
    {
        _rotationToEnemy = new TurretRotationToEnemy(_towerRadar, transform);
        _idleAnimation = new TurretIdleAnimation(transform);
    }

    private void Update()
    {
        IUpdatable updatable = _towerRadar.HasTarget ? _rotationToEnemy : (IUpdatable)_idleAnimation;
        updatable.Update();
    }
}