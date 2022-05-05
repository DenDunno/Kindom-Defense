using UnityEngine;

public abstract class WeaponRotation : MonoBehaviour
{
    [SerializeField] private TowerRadar _towerRadar;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _pillar;
    private IUpdatable _rotationToEnemy;
    private IUpdatable _idleAnimation;

    private void Start()
    {
        _rotationToEnemy = new WeaponRotationToEnemy(_towerRadar, _pillar, GetHeadRotationToEnemy(_towerRadar, _head));
        _idleAnimation = new WeaponIdleAnimation(_pillar, GetHeadIdleAnimation(_head));
    }

    private void Update()
    {
        IUpdatable updatable = _towerRadar.HasTarget ? _rotationToEnemy : _idleAnimation;
        updatable.Update();
    }

    protected abstract IWeaponHeadIdleAnimation GetHeadIdleAnimation(Transform head);
    protected abstract IWeaponHeadRotationToEnemy GetHeadRotationToEnemy(TowerRadar towerRadar, Transform head);
}