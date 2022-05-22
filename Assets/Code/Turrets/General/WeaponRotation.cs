using UnityEngine;

public abstract class WeaponRotation : MonoBehaviour
{
    [SerializeField] private WeaponRadar _weaponRadar;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _pillar;
    [SerializeField] private float _idleAngle;
    private WeaponRotationToEnemy _rotationToEnemy;
    private IUpdatable _idleAnimation;

    public bool ReadyForShooting => _rotationToEnemy.TurnedToEnemy;

    private void Start()
    {
        IWeaponHeadRotationToEnemy headRotationToEnemy = GetHeadRotationToEnemy(_weaponRadar, _head);
        _rotationToEnemy = new WeaponRotationToEnemy(_weaponRadar, _pillar, _head, headRotationToEnemy);
        _idleAnimation = new WeaponIdleAnimation(_pillar, _head, _idleAngle);
    }

    private void Update()
    {
        IUpdatable updatable = _weaponRadar.HasTarget ? _rotationToEnemy : _idleAnimation;
        updatable.Update();
    }

    protected abstract IWeaponHeadRotationToEnemy GetHeadRotationToEnemy(WeaponRadar weaponRadar, Transform head);
}