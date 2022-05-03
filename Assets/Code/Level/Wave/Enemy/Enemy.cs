using UnityEngine;

public class Enemy : MonoBehaviour, IPoolableObject
{
    [SerializeField] private EnemyHealth _enemyHealth;

    public bool IsActive => _enemyHealth.IsDead == false;
}