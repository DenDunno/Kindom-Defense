using System.Collections.Generic;
using UnityEngine;

public class TowerRadar : MonoBehaviour
{
    private readonly List<EnemyHealth> _detectedEnemies = new List<EnemyHealth>();
    
    public EnemyHealth ClosestEnemy { get; private set; }
    public bool HasTarget => ClosestEnemy != null;

    private void Update()
    {
        if (_detectedEnemies.Contains(ClosestEnemy) == false || IsDead())
        {
            FindClosestEnemy();
        }
    }

    private bool IsDead()
    {
        var result = true;

        if (ClosestEnemy != null)
            result = ClosestEnemy.IsDead;

        return result;
    }

    private void FindClosestEnemy()
    {
        float minDistanceToEnemy = float.MaxValue;
        ClosestEnemy = null;
        
        foreach (EnemyHealth detectedEnemy in _detectedEnemies)
        {
            if (detectedEnemy.IsDead == false)
            {
                float distanceToEnemy = (detectedEnemy.transform.position - transform.position).sqrMagnitude;

                if (distanceToEnemy < minDistanceToEnemy)
                {
                    minDistanceToEnemy = distanceToEnemy;
                    ClosestEnemy = detectedEnemy;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider enemy)
    {
        _detectedEnemies.Add(enemy.GetComponent<EnemyHealth>());
    }

    private void OnTriggerExit(Collider enemy)
    {
        _detectedEnemies.Remove(enemy.GetComponent<EnemyHealth>());
    }
}