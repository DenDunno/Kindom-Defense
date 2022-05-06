using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    [SerializeField] private Weapon _upgradedWeapon;

    public Weapon UpgradedWeapon => _upgradedWeapon;
}