using UnityEngine;

public class TurretHeadRotationToEnemy : IWeaponHeadRotationToEnemy
{
    private readonly WeaponRadar _weaponRadar;
    private readonly Transform _head;
    private const float _maxAngle = 30;
    private const float _rotationToEnemySpeed = 8;

    public TurretHeadRotationToEnemy(WeaponRadar weaponRadar, Transform head)
    {
        _weaponRadar = weaponRadar;
        _head = head;
    }
    
    void IWeaponHeadRotationToEnemy.RotateHeadToEnemy()
    {
        float xRotation = Quaternion.LookRotation(_weaponRadar.TargetEnemy.transform.position - _head.position).eulerAngles.x;

        if (xRotation > _maxAngle)
            xRotation = _maxAngle;

        _head.localRotation = Quaternion.Lerp(_head.localRotation, Quaternion.Euler(xRotation, 0, 0), _rotationToEnemySpeed * Time.deltaTime);
    }
}