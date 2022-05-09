using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyRadar
{
    private readonly Collider[] _colliders;
    private readonly float _detectionRadius;
    private readonly Transform _origin;
    private const int _enemyLayerMask = 1 << 8;
    
    public EnemyRadar(int collidersBufferSize, Transform origin, float detectionRadius)
    {
        _colliders = new Collider[collidersBufferSize];
        _detectionRadius = detectionRadius;
        _origin = origin;
    }

    public IReadOnlyCollection<Health> FindEnemies()
    {
        int size = Physics.OverlapSphereNonAlloc(_origin.position, _detectionRadius, _colliders, _enemyLayerMask);
        var enemies = new List<Health>();
        
        for (var i = 0; i < size; ++i)
        {
            var enemy = _colliders[i].GetComponent<Health>();
            
            if (enemy.IsDead == false)
            {
                enemies.Add(enemy);
            }
        }

        return enemies;
    }

    public Health FindTarget()
    {
        IReadOnlyCollection<Health> enemies = FindEnemies();
        
        if (enemies.Count == 0)
            return null;

        return enemies.First();
    }
}