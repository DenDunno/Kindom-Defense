using UnityEngine;

public class TurretRotation : WeaponRotation
{
    protected override IWeaponHeadIdleAnimation GetHeadIdleAnimation(Transform head)
    {
        return new TurretHeadIdleAnimation(head);
    }

    protected override IWeaponHeadRotationToEnemy GetHeadRotationToEnemy(TowerRadar towerRadar, Transform head)
    {
        return new TurretHeadRotationToEnemy(towerRadar, head);
    }
}