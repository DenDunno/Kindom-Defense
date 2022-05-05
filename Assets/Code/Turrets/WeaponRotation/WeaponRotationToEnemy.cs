using UnityEngine;

public class WeaponRotationToEnemy : IUpdatable
{
    private readonly TowerRadar _towerRadar;
    private readonly Transform _pillar;
    private readonly IWeaponHeadRotationToEnemy _weaponHeadRotationToEnemy;
    private const float _rotationToEnemySpeed = 8;

    public WeaponRotationToEnemy(TowerRadar towerRadar, Transform pillar, IWeaponHeadRotationToEnemy weaponHeadRotationToEnemy)
    {
        _towerRadar = towerRadar;
        _pillar = pillar;
        _weaponHeadRotationToEnemy = weaponHeadRotationToEnemy;
    }
    
    void IUpdatable.Update()
    {
        RotatePillarToEnemy();
        _weaponHeadRotationToEnemy.RotateHeadToEnemy();
    }

    private void RotatePillarToEnemy()
    {
        Quaternion lookAtRotation = Quaternion.LookRotation(_towerRadar.TargetEnemy.transform.position - _pillar.position);
        
        lookAtRotation = Quaternion.Euler(0, lookAtRotation.eulerAngles.y, 0);
        
        _pillar.rotation = Quaternion.Lerp(_pillar.rotation, lookAtRotation, _rotationToEnemySpeed * Time.deltaTime);
    }
}