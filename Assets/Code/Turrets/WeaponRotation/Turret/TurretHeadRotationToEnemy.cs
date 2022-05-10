using UnityEngine;

public class TurretHeadRotationToEnemy : IWeaponHeadRotationToEnemy
{
    private readonly WeaponRadar _weaponRadar;
    private readonly Transform _head;
    private const float _maxAngle = 30;
    
    public TurretHeadRotationToEnemy(WeaponRadar weaponRadar, Transform head)
    {
        _weaponRadar = weaponRadar;
        _head = head;
    }

    public float Angle
    {
        get
        {
            float xRotation = Quaternion.LookRotation(_weaponRadar.Target.position - _head.position).eulerAngles.x;
            
            if (xRotation < 90 && xRotation > _maxAngle)
                xRotation = _maxAngle;

            return xRotation;
        }
    }
}