using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    private float _maxHealth;

    public event Action<Health> Died;
    public event Action<float, float> DamageTaken;
    public bool IsDead => _health <= 0;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        if (_health <= 0)
            return;
        
        _health -= damage;
        DamageTaken?.Invoke(_health, _maxHealth);
        
        if (_health <= 0)
            Died?.Invoke(this);
    }

    public void ResetHealth()
    {
        _health = _maxHealth;
    }
}