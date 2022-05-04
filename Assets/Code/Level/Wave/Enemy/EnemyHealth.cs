using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    private float _maxHealth;
    
    public event Action Died;
    public event Action<float> DamageTaken;
    
    public bool IsDead => _health <= 0;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        
        if (_health <= 0)
        {
            _health = 0;
            Died?.Invoke();
        }
        
        DamageTaken?.Invoke(_health / _maxHealth);
    }

    public void ResetHealth()
    {
        _health = _maxHealth;
    }
}