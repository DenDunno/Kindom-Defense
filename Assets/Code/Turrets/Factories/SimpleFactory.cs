using UnityEngine;

public class SimpleFactory<T> : IFactory<T> where T : MonoBehaviour
{
    private readonly T _prefab;

    public SimpleFactory(T prefab)
    {
        _prefab = prefab;
    }
    
    public T Create()
    {
        return Object.Instantiate(_prefab);
    }
}