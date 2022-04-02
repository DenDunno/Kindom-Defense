using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _health = 100;

    public bool IsDead => _health < 0; 

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }
}