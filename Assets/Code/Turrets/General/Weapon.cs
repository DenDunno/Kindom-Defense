using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponRadar _weaponRadar;
    [SerializeField] private WeaponSettings _settings;

    public WeaponSettings Settings => _settings;
    
    private void Update()
    {
        if (_weaponRadar.HasTarget)
        {
            UpdateWeapon(_weaponRadar.Target);
        }
    }

    protected abstract void UpdateWeapon(Transform targetEnemy);
}