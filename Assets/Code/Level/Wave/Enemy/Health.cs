using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] private HealthBar _healthBar;
    private float _maxHealth;

    public event Action<Health> Died;
    public bool IsDead => _health <= 0;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        if (_health <= 0)
            return;
        
        SetHealth(_health - damage);
        
        if (_health <= 0)
            Died?.Invoke(this);
    }

    public void ResetHealth()
    {
        SetHealth(_maxHealth);
        _healthBar.gameObject.SetActive(false);
    }

    private void SetHealth(float health)
    {
        _health = health;
        _healthBar.UpdateValue(_health / _maxHealth);
    }
}