using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemiesSpawner : IUpdatable
{
    private readonly Transform _kingdom;
    private readonly Transform _waveSpawner;
    private readonly Camera _mainCamera;

    private readonly Dictionary<AssetReference, ObjectFactory<Enemy>> _enemyPool = 
        new Dictionary<AssetReference, ObjectFactory<Enemy>>();

    public EnemiesSpawner(Kingdom kingdom, WaveSpawner waveSpawner, Camera mainCamera)
    {
        _kingdom = kingdom.transform;
        _waveSpawner = waveSpawner.transform;
        _mainCamera = mainCamera;
    }
    
    public async void Spawn(AssetReference enemyReference)
    {
        GameObject enemyGameObject = await Addressables.InstantiateAsync(enemyReference);
        enemyGameObject.transform.parent = _waveSpawner;
        
        var enemyStartup = enemyGameObject.GetComponent<EnemyStartup>();
        enemyStartup.Init(_kingdom, _mainCamera);
    }

    public void Update()
    {
        foreach (IUpdatable enemyFactory in _enemyPool.Values)
        {
            enemyFactory.Update();
        }
    }
}