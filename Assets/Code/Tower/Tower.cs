using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform _buildPosition;
    private Weapon _weapon;

    public bool HasWeapon => _weapon != null;
    public Weapon Weapon => _weapon;
    
    public void BuildWeapon(Weapon weaponPrefab)
    {
        _weapon = Instantiate(weaponPrefab, _buildPosition.position, Quaternion.identity, transform);
    }

    public void UpgradeWeapon(Weapon weaponPrefab)
    {
        DestroyWeapon();
        BuildWeapon(weaponPrefab);
    }
    
    public void DestroyWeapon()
    {
        Destroy(_weapon.gameObject);
    }
}