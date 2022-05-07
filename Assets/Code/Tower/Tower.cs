using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform _detectionRadius;
    [SerializeField] private Transform _buildPosition;
    [SerializeField] private TowerUpgrade _towerUpgrade;
    [SerializeField] private TowerSelection _towerSelection;
    private WeaponPresenter _weaponPresenter;

    public bool IsSelected => _towerSelection.IsSelected;

    public void BuildWeapon(WeaponPresenter weaponPrefab)
    {
        _weaponPresenter = Instantiate(weaponPrefab, _buildPosition.position, Quaternion.identity, transform);
        _detectionRadius.localScale = Vector3.one * (_weaponPresenter.Radar.DetectionRadius * 2);
    }

    public void Upgrade()
    {
        _towerUpgrade.Upgrade();
        WeaponPresenter upgradedWeapon = _weaponPresenter.UpgradedWeapon;
        DestroyWeapon();
        BuildWeapon(upgradedWeapon);
    }

    public void Sold()
    {
        DestroyWeapon();
        _towerUpgrade.ReturnStartView();
    }

    private void DestroyWeapon()
    {
        Destroy(_weaponPresenter.gameObject);
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