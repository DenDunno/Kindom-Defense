using Cysharp.Threading.Tasks;
using UnityEngine;

public interface ISpawnMethod
{
    UniTask<GameObject> Instantiate();
}