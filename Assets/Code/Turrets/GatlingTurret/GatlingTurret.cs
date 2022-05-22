using UnityEngine;

public class GatlingTurret : Turret
{
    [SerializeField] private GatlingBarrel _gatlingBarrel;

    protected override void UpdateWeapon(Transform targetEnemy)
    {
        if (_gatlingBarrel.ReadyForShooting)
        {
            base.UpdateWeapon(targetEnemy);
        }
    }
}