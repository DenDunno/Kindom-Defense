using System.Collections.Generic;
using UnityEngine;

public class TowerRadar : MonoBehaviour
{
    private readonly List<Transform> _detectedEnemies = new List<Transform>();
    
    public Transform ClosestEnemy { get; private set; }
    public bool HasTarget => ClosestEnemy != null;

    private void Update()
    {
        FindClosestEnemy();
    }

    private void FindClosestEnemy()
    {
        float minDistanceToEnemy = float.MaxValue;
        ClosestEnemy = null;
        
        foreach (Transform detectedEnemy in _detectedEnemies)
        {
            float distanceToEnemy = (detectedEnemy.position - transform.position).sqrMagnitude;

            if (distanceToEnemy < minDistanceToEnemy)
            {
                minDistanceToEnemy = distanceToEnemy;
                ClosestEnemy = detectedEnemy;
            }
        }
    }

    private void OnTriggerEnter(Collider enemy)
    {
        _detectedEnemies.Add(enemy.transform);
    }

    private void OnTriggerExit(Collider enemy)
    {
        _detectedEnemies.Remove(enemy.transform);
    }
}