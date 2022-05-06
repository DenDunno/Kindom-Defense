using System;
using UnityEngine;

public class WeaponPresenter : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private WeaponRadar _weaponRadar;
    [SerializeField] private WeaponUpgrade _weaponUpgrade;
    
    public Weapon Weapon => _weapon;
    public WeaponRadar Radar => _weaponRadar;
    public WeaponUpgrade Upgrade => _weaponUpgrade;

    private void Start()
    {
        throw new NotImplementedException();
    }
}