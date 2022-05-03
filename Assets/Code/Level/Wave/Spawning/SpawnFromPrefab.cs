using Cysharp.Threading.Tasks;
using UnityEngine;

public class SpawnFromPrefab : ISpawnMethod
{
    private readonly GameObject _prefab;

    public SpawnFromPrefab(GameObject prefab)
    {
        _prefab = prefab;
    }

    async UniTask<GameObject> ISpawnMethod.Instantiate()
    {
        return Object.Instantiate(_prefab);
    }
}