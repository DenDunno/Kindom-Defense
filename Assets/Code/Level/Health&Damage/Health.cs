using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    
    public event Action DamageTaken;
    public event Action Destroyed;

    public bool IsDead => _health < 0;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            Destroyed?.Invoke();
        }

        else
        {
            DamageTaken?.Invoke();
        }
    }
}