using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemiesFactory : IUpdatable
{
    private readonly List<AssetReference> _enemiesUsedInLevel;
    private readonly Dictionary<string, ObjectPool<Enemy>> _enemiesFactories = new Dictionary<string, ObjectPool<Enemy>>();

    public EnemiesFactory(List<AssetReference> enemiesUsedInLevel)
    {
        _enemiesUsedInLevel = enemiesUsedInLevel;
    }

    public async void LoadEnemies()
    {
        foreach (AssetReference enemyReference in _enemiesUsedInLevel)
        {
            GameObject enemy = await Addressables.LoadAssetAsync<GameObject>(enemyReference).Task;
            var enemyStartup = enemy.GetComponent<Enemy>();
            _enemiesFactories[enemyReference.AssetGUID] = new ObjectPool<Enemy>(enemyStartup);
        }
    }

    public Enemy Create(AssetReference enemyReference)
    {
        return _enemiesFactories[enemyReference.AssetGUID].Create();
    }

    void IUpdatable.Update()
    {
        foreach (ObjectPool<Enemy> enemyFactory in _enemiesFactories.Values)
        {
            enemyFactory.Update();
        }
    }
}