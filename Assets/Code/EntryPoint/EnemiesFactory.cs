using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemiesFactory : MonoBehaviour
{
    [SerializeField] private List<AssetReference> _enemiesUsedInLevel;
    
    private readonly Dictionary<string, ObjectFactory<Enemy>> _enemiesFactories = 
        new Dictionary<string, ObjectFactory<Enemy>>();

    public async void LoadEnemies()
    {
        foreach (AssetReference enemyReference in _enemiesUsedInLevel)
        {
            GameObject enemy = await Addressables.LoadAssetAsync<GameObject>(enemyReference).Task;
            var enemyStartup = enemy.GetComponent<Enemy>();
            _enemiesFactories[enemyReference.AssetGUID] = new ObjectFactory<Enemy>(enemyStartup);
        }
    }
    
    public Enemy Create(AssetReference enemyReference)
    {
        return _enemiesFactories[enemyReference.AssetGUID].Create();
    }

    private void Update()
    {
        foreach (ObjectFactory<Enemy> enemyFactory in _enemiesFactories.Values)
        {
            enemyFactory.Update();
        }
    }
}