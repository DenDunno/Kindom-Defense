using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TimeField : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private readonly List<EnemySpeed> _enemies = new List<EnemySpeed>();
    private const float _skillDuration = 10f;
    
    public async void Cast(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
        gameObject.SetActive(true);
        _particleSystem.Play();

        await UniTask.Delay(TimeSpan.FromSeconds(_skillDuration));
        gameObject.SetActive(false);
        
        foreach (EnemySpeed enemySpeed in _enemies)
        {
            enemySpeed.ReturnStartSpeed();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<EnemySpeed>();
        
        enemy.SlowDown();
        _enemies.Add(enemy);
    }

    private void OnTriggerExit(Collider other)
    {
        var enemy = other.GetComponent<EnemySpeed>();
        
        enemy.ReturnStartSpeed();
        _enemies.Remove(enemy);
    }
}