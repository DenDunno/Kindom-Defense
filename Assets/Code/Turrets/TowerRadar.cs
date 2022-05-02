using System.Collections.Generic;
using UnityEngine;

public class TowerRadar : MonoBehaviour
{
    private readonly List<Collider> _detectedEnemies = new List<Collider>();
    public Collider ClosestEnemy { get; private set; }

    private void Update()
    {
        FindClosestEnemy();
    }

    private void FindClosestEnemy()
    {
        float minDistanceToEnemy = float.MaxValue;
        
        foreach (Collider detectedEnemy in _detectedEnemies)
        {
            float distanceToEnemy = (detectedEnemy.transform.position - transform.position).sqrMagnitude;

            if (distanceToEnemy < minDistanceToEnemy)
            {
                minDistanceToEnemy = distanceToEnemy;
                ClosestEnemy = detectedEnemy;
            }
        }
    }

    private void OnTriggerEnter(Collider enemy)
    {
        _detectedEnemies.Add(enemy);
    }

    private void OnTriggerExit(Collider enemy)
    {
        _detectedEnemies.Remove(enemy);
    }
}