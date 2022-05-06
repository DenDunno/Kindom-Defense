using UnityEngine;

public class TurretRotation : WeaponRotation
{
    protected override IWeaponHeadIdleAnimation GetHeadIdleAnimation(Transform head)
    {
        return new TurretHeadIdleAnimation(head);
    }

    protected override IWeaponHeadRotationToEnemy GetHeadRotationToEnemy(WeaponRadar weaponRadar, Transform head)
    {
        return new TurretHeadRotationToEnemy(weaponRadar, head);
    }
}