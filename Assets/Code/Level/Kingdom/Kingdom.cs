using UnityEngine;

public class Kingdom : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponentInParent<Enemy>();
        enemy.MarkAsInactive();

        _health.TakeDamage(enemy.Stats.Damage);
    }
}