using UnityEngine;

public abstract class WeaponRotation : MonoBehaviour
{
    [SerializeField] private WeaponRadar _weaponRadar;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _pillar;
    private IUpdatable _rotationToEnemy;
    private IUpdatable _idleAnimation;

    private void Start()
    {
        _rotationToEnemy = new WeaponRotationToEnemy(_weaponRadar, _pillar, GetHeadRotationToEnemy(_weaponRadar, _head));
        _idleAnimation = new WeaponIdleAnimation(_pillar, GetHeadIdleAnimation(_head));
    }

    private void Update()
    {
        IUpdatable updatable = _weaponRadar.HasTarget ? _rotationToEnemy : _idleAnimation;
        updatable.Update();
    }

    protected abstract IWeaponHeadIdleAnimation GetHeadIdleAnimation(Transform head);
    protected abstract IWeaponHeadRotationToEnemy GetHeadRotationToEnemy(WeaponRadar weaponRadar, Transform head);
}