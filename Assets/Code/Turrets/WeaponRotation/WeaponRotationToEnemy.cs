using UnityEngine;

public class WeaponRotationToEnemy : IUpdatable
{
    private readonly WeaponRadar _weaponRadar;
    private readonly Transform _pillar;
    private readonly Transform _head;
    private readonly IWeaponHeadRotationToEnemy _weaponHeadRotationToEnemy;
    private const float _rotationToEnemySpeed = 8;
    private const float _turnedToEnemyAngle = 5;

    public WeaponRotationToEnemy(WeaponRadar weaponRadar, Transform pillar, Transform head, IWeaponHeadRotationToEnemy weaponHeadRotationToEnemy)
    {
        _weaponHeadRotationToEnemy = weaponHeadRotationToEnemy;
        _weaponRadar = weaponRadar;
        _pillar = pillar;
        _head = head;
    }

    public bool TurnedToEnemy { get; private set; }

    void IUpdatable.Update()
    {
        RotatePillarToEnemy();
        RotateHeadToEnemy();
    }

    private void RotateHeadToEnemy()
    {
        Quaternion rotation = Quaternion.Euler(_weaponHeadRotationToEnemy.Angle, 0, 0);
        _head.localRotation = Quaternion.Lerp(_head.localRotation, rotation, _rotationToEnemySpeed * Time.deltaTime);
    }

    private void RotatePillarToEnemy()
    {
        Quaternion lookAtRotation = Quaternion.LookRotation(_weaponRadar.TargetPosition - _pillar.position);

        TurnedToEnemy = Mathf.Abs(lookAtRotation.eulerAngles.y - _pillar.rotation.eulerAngles.y) < _turnedToEnemyAngle;
        
        lookAtRotation = Quaternion.Euler(0, lookAtRotation.eulerAngles.y, 0);
        
        _pillar.rotation = Quaternion.Lerp(_pillar.rotation, lookAtRotation, _rotationToEnemySpeed * Time.deltaTime);
    }
}