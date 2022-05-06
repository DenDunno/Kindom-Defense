using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform _buildPosition;
    private WeaponPresenter _weaponPresenter;

    public bool HasWeapon => _weaponPresenter != null;
    public float DetectionRadius => _weaponPresenter.Radar.DetectionRadius;
    
    public void BuildWeapon(WeaponPresenter weaponPrefab)
    {
        _weaponPresenter = Instantiate(weaponPrefab, _buildPosition.position, Quaternion.identity, transform);
    }

    public void UpgradeWeapon()
    {
        DestroyWeapon();
     //   BuildWeapon(_weaponPresenter.up);
    }
    
    public void DestroyWeapon()
    {
        Destroy(_weaponPresenter.gameObject);
    }
}