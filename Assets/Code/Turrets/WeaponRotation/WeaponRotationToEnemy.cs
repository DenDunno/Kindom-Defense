using UnityEngine;

public class WeaponRotationToEnemy : IUpdatable
{
    private readonly WeaponRadar _weaponRadar;
    private readonly Transform _pillar;
    private readonly IWeaponHeadRotationToEnemy _weaponHeadRotationToEnemy;
    private const float _rotationToEnemySpeed = 8;
    private const float _turnedToEnemyAngle = 5;

    public WeaponRotationToEnemy(WeaponRadar weaponRadar, Transform pillar, IWeaponHeadRotationToEnemy weaponHeadRotationToEnemy)
    {
        _weaponHeadRotationToEnemy = weaponHeadRotationToEnemy;
        _weaponRadar = weaponRadar;
        _pillar = pillar;
    }

    public bool TurnedToEnemy { get; private set; }

    void IUpdatable.Update()
    {
        RotatePillarToEnemy();
        _weaponHeadRotationToEnemy.RotateHeadToEnemy();
    }

    private void RotatePillarToEnemy()
    {
        Quaternion lookAtRotation = Quaternion.LookRotation(_weaponRadar.Target.transform.position - _pillar.position);

        TurnedToEnemy = Mathf.Abs(lookAtRotation.eulerAngles.y - _pillar.rotation.eulerAngles.y) < _turnedToEnemyAngle;
        
        lookAtRotation = Quaternion.Euler(0, lookAtRotation.eulerAngles.y, 0);
        
        _pillar.rotation = Quaternion.Lerp(_pillar.rotation, lookAtRotation, _rotationToEnemySpeed * Time.deltaTime);
    }
}