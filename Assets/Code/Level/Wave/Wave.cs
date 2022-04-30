using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Wave
{
    [SerializeField] private float _delay;
    [SerializeField] private float _spawnRate;
    [SerializeField] private List<Enemy> _enemies;

    public float Delay => _delay;
    public float SpawnRate => _spawnRate;
    public IReadOnlyList<Enemy> Enemies => _enemies;
}