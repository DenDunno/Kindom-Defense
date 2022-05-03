using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SpawnFromAssetReference : ISpawnMethod
{
    private readonly AssetReference _assetReference;

    public SpawnFromAssetReference(AssetReference assetReference)
    {
        _assetReference = assetReference;
    }
    
    async UniTask<GameObject> ISpawnMethod.Instantiate()
    {
        return await Addressables.InstantiateAsync(_assetReference);
    }
}