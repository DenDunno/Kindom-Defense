using UnityEngine;

public class Kingdom : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void Start()
    {
        _health.Init();
    }

    private void OnTriggerEnter(Collider enemyCollider)
    {
        var enemy = enemyCollider.GetComponent<Enemy>();
        enemy.MarkAsInactive();

        _health.TakeDamage(enemy.Stats.Damage);
    }
}