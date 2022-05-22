using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerViewUpgrade _towerViewUpgrade;
    [SerializeField] private Transform _buildPosition;
    private PlayerGold _playerGold;
    private TurretBuilding _turretBuilding;
    
    public Weapon Weapon { get; private set; }

    public void Init(PlayerGold playerGold, TurretBuilding turretBuilding)
    {
        _playerGold = playerGold;
        _turretBuilding = turretBuilding;
    }
    
    public void BuildWeapon(Weapon weaponPrefab)
    {
        Weapon = _turretBuilding.Build(weaponPrefab);
        Weapon.transform.parent = transform;
        Weapon.transform.position = _buildPosition.position;
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