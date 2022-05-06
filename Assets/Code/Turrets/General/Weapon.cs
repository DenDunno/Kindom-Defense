using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponRadar _weaponRadar;

    private void Update()
    {
        if (_weaponRadar.HasTarget)
        {
            UpdateWeapon(_weaponRadar.TargetEnemy.transform);
        }
    }

    protected abstract void UpdateWeapon(Transform targetEnemy);
}