using UnityEngine;

public class MortarRotation : WeaponRotation
{
    protected override float IdleAngle => -45;
    
    protected override IWeaponHeadRotationToEnemy GetHeadRotationToEnemy(WeaponRadar weaponRadar, Transform head)
    {
        return new MortarHeadRotationToEnemy(weaponRadar, head);
    }
}