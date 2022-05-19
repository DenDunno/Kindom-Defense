using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerViewUpgrade _towerViewUpgrade;
    [SerializeField] private Transform _buildPosition;
    private PlayerGold _playerGold;

    public Weapon Weapon { get; private set; }

    public void Init(PlayerGold playerGold)
    {
        _playerGold = playerGold;
    }
    
    public void BuildWeapon(Weapon weaponPrefab)
    {
        Weapon = Instantiate(weaponPrefab, _buildPosition.position, Quaternion.identity, transform);
        _playerGold.Buy(Weapon.Settings.Price);
    }

    public void Upgrade()
    {
        _towerViewUpgrade.Upgrade();
        Weapon upgradedWeapon = Weapon.Settings.UpgradedWeapon;
        _playerGold.Buy(upgradedWeapon.Settings.Price);
        DestroyWeapon();
        BuildWeapon(upgradedWeapon);
    }

    public void Sold()
    {
        _playerGold.SoldWeapon(Weapon.Settings.SellPrice);
        DestroyWeapon();
        _towerViewUpgrade.ReturnStartView();
    }

    private void DestroyWeapon()
    {
        Destroy(Weapon.gameObject);
    }
}