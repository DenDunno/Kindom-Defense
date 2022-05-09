using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerViewUpgrade _towerViewUpgrade;
    [SerializeField] private Transform _buildPosition;
    private PlayerGold _playerGold;

    public WeaponPresenter Weapon { get; private set; }

    public void Init(PlayerGold playerGold)
    {
        _playerGold = playerGold;
    }
    
    public void BuildWeapon(WeaponPresenter weaponPrefab)
    {
        Weapon = Instantiate(weaponPrefab, _buildPosition.position, Quaternion.identity, transform);
        _playerGold.Buy(weaponPrefab.Price);
    }

    public void Upgrade()
    {
        _towerViewUpgrade.Upgrade();
        WeaponPresenter upgradedWeapon = Weapon.UpgradedWeapon;
        _playerGold.Buy(upgradedWeapon.Price);
        DestroyWeapon();
        BuildWeapon(upgradedWeapon);
    }

    public void Sold()
    {
        _playerGold.SoldWeapon(Weapon.SellPrice);
        DestroyWeapon();
        _towerViewUpgrade.ReturnStartView();
    }

    private void DestroyWeapon()
    {
        Destroy(Weapon.gameObject);
    }
}