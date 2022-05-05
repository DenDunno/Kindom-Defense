using UnityEngine;

public class TowerBase : MonoBehaviour
{
    [SerializeField] private Transform _buildPosition;
    private Weapon _weapon;
    
    public void BuildWeapon(Weapon weaponPrefab)
    {
        _weapon = Instantiate(weaponPrefab, _buildPosition.position, Quaternion.identity, transform);
    }
    
    public void DestroyWeapon()
    {
        Destroy(_weapon.gameObject);
    }
}