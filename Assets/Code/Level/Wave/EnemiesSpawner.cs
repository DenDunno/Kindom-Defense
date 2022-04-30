using UnityEngine;

public class EnemiesSpawner
{
    private readonly Vector3 _enemyTargetPosition;
    private readonly Transform _enemyStartPosition;

    public EnemiesSpawner(Kingdom kingdom, WaveSpawner waveSpawner)
    {
        _enemyTargetPosition = kingdom.transform.position;
        _enemyStartPosition = waveSpawner.transform;
    }
    
    public void Spawn(Enemy prefab)
    {
        Enemy enemy = Object.Instantiate(prefab, _enemyStartPosition);
        enemy.Init(_enemyTargetPosition);
    }
}