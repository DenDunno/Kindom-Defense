using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    public event Action Died;
    
    public bool IsDead => _health < 0;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            Died?.Invoke();
        }
    }
}