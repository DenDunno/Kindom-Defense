using UnityEngine;

public class TurretRotation : WeaponRotation
{
    protected override float IdleAngle => 0;

    protected override IWeaponHeadRotationToEnemy GetHeadRotationToEnemy(WeaponRadar weaponRadar, Transform head)
    {
        return new TurretHeadRotationToEnemy(weaponRadar, head);
    }
}