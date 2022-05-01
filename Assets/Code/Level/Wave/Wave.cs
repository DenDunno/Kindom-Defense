using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


[Serializable]
public class Wave
{
    [SerializeField] private float _delay;
    [SerializeField] private float _spawnRate;
    [SerializeField] private List<AssetReference> _enemies;

    public float Delay => _delay;
    public float SpawnRate => _spawnRate;
    public IReadOnlyList<AssetReference> Enemies => _enemies;
}