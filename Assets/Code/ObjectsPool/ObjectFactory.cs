using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory<T> : IUpdatable where T : MonoBehaviour, IPoolableObject
{
    private readonly T _prefab;
    private readonly Stack<T> _pool = new Stack<T>();
    private readonly List<T> _activeObjects = new List<T>();
    
    public ObjectFactory(T prefab)
    {
        _prefab = prefab;
    }

    public T Create()
    {
        T poolableObject = SpawnOrPop();
        poolableObject.gameObject.SetActive(true);
        _activeObjects.Add(poolableObject);

        return poolableObject;
    }

    private T SpawnOrPop()
    {
        if (_pool.IsEmpty())
        {
            return Object.Instantiate(_prefab);
        }
        
        T poolableObject = _pool.Pop();
        poolableObject.ResetObject();
        return poolableObject;
    }

    public void Update()
    {
        for (int i = 0 ; i < _activeObjects.Count; ++i)
        {
            if (_activeObjects[i].IsActive == false)
            {
                _pool.Push(_activeObjects[i]);
                _activeObjects.Remove(_activeObjects[i]);
            }
        }
    }
}