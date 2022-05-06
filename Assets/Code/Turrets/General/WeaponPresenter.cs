using UnityEngine;

public class WeaponPresenter : MonoBehaviour
{
    [SerializeField] private WeaponRadar _weaponRadar;
    [SerializeField] private WeaponPresenter _upgradedWeapon;
    
    public WeaponRadar Radar => _weaponRadar;
    public WeaponPresenter UpgradedWeapon => _upgradedWeapon;
}