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
        _towerSelection.HasWeapon(true);
    }

    public void Upgrade()
    {
        _towerUpgrade.Upgrade();
        DestroyWeapon();
        BuildWeapon(_weaponPresenter.UpgradedWeapon);
    }

    private void DestroyWeapon()
    {
        Destroy(_weaponPresenter.gameObject);
        _towerSelection.HasWeapon(false);
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