using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemiesSpawner : IUpdatable
{
    private readonly Vector3 _enemyTargetPosition;
    private readonly Transform _enemyStartPosition;
    private Dictionary<AssetReference, Stack<Enemy>> _enemyPool = new Dictionary<AssetReference, Stack<Enemy>>();
    private Queue<Enemy> _activeEnemies = new Queue<Enemy>();
    
    public EnemiesSpawner(Kingdom kingdom, WaveSpawner waveSpawner)
    {
        _enemyTargetPosition = kingdom.transform.position;
        _enemyStartPosition = waveSpawner.transform;
    }
    
    public async void Spawn(AssetReference enemyReference)
    {
        GameObject enemyGameObject = await Addressables.InstantiateAsync(enemyReference, _enemyStartPosition.position, Quaternion.identity, _enemyStartPosition);
        
        var enemy = enemyGameObject.GetComponent<Enemy>();
        enemy.Init(_enemyTargetPosition);
    }

    public void Update()
    {
    }
}