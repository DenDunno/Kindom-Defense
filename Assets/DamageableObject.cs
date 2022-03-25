using System;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] private float _health = 100;

    public event Action DamageTaken;
    public event Action Destroyed;

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