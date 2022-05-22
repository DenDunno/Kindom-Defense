using UnityEngine;

[CreateAssetMenu(fileName = "BulletStats", menuName = "ScriptableObjects/BulletStats", order = 5)]
public class BulletStats : ScriptableObject
{
    [SerializeField] private float _damage = 15;
    [SerializeField] private float _speed = 15f;

    public float Damage => _damage;
    public float Speed => _speed;
}