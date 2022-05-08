using UnityEngine;

public class  WeaponPresenter : MonoBehaviour
{
    [SerializeField] private WeaponRadar _weaponRadar;
    [SerializeField] private WeaponPresenter _upgradedWeapon;
    [SerializeField] private int _price;
    [SerializeField] private int _sellPrice;
    
    public WeaponRadar Radar => _weaponRadar;
    public WeaponPresenter UpgradedWeapon => _upgradedWeapon;
    public int Price => _price;
    public int SellPrice => _sellPrice;
}