using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform _detectionRadius;
    [SerializeField] private Transform _buildPosition;
    [SerializeField] private TowerUpgrade _towerUpgrade;
    [SerializeField] private TowerSelection _towerSelection;
    private PlayerGold _playerGold;
    
    public bool IsSelected => _towerSelection.IsSelected;
    public WeaponPresenter WeaponPresenter { get; private set; }

    public void Init(PlayerGold playerGold)
    {
        _playerGold = playerGold;
    }
    
    public void BuildWeapon(WeaponPresenter weaponPrefab)
    {
        WeaponPresenter = Instantiate(weaponPrefab, _buildPosition.position, Quaternion.identity, transform);
        _detectionRadius.localScale = Vector3.one * (WeaponPresenter.Radar.DetectionRadius * 2);
        _playerGold.TryBuy(weaponPrefab.Price);
    }

    public void Upgrade()
    {
        _towerUpgrade.Upgrade();
        WeaponPresenter upgradedWeapon = WeaponPresenter.UpgradedWeapon;
        _playerGold.TryBuy(upgradedWeapon.Price);
        DestroyWeapon();
        BuildWeapon(upgradedWeapon);
    }

    public void Sold()
    {
        _playerGold.SoldWeapon(WeaponPresenter.SellPrice);
        DestroyWeapon();
        _towerUpgrade.ReturnStartView();
    }

    private void DestroyWeapon()
    {
        Destroy(WeaponPresenter.gameObject);
    }

    public void Select()
    {
        _towerSelection.Select();
    }
    
    public void Unselect()
    {
        _towerSelection.Unselect();
    }
}