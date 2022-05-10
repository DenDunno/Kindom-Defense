using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 3)]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private int _reward = 3;
    [SerializeField] private int _damage = 5;

    public int Reward => _reward;
    public int Damage => _damage;
}