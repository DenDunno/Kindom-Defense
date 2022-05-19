using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSettings", menuName = "ScriptableObjects/WeaponSettings", order = 4)]
public class WeaponSettings : ScriptableObject
{
    [SerializeField] private Weapon _upgradedWeapon;
    [SerializeField] private float _detectionRadius;
    [SerializeField] private int _price;
    [SerializeField] private int _sellPrice;
    
    public Weapon UpgradedWeapon => _upgradedWeapon;
    public float DetectionRadius => _detectionRadius;
    public int Price => _price;
    public int SellPrice => _sellPrice;
    public bool HasUpgrade => UpgradedWeapon != null;
}