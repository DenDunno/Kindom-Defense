using UnityEngine;

public class GatlingTurret : Turret
{
    [SerializeField] private GatlingBarrel _gatlingBarrel;

    protected override bool ConditionForShooting => _gatlingBarrel.ReadyForShooting;
}