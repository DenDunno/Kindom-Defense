using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveList _waveList;
    [SerializeField] private Kingdom _kingdom;
    private Stack<Wave> _waves;
    private EnemiesSpawner _enemiesSpawner;
    
    private IEnumerator Start()
    {
        _waves = _waveList.Waves;
        _enemiesSpawner = new EnemiesSpawner(_kingdom, this);

        for (int i = 0; i < _waveList.Waves.Count; i++)
        {
            yield return StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        if (_waves.IsNotEmpty())
        {
            Wave wave = _waves.Pop();

            yield return new WaitForSeconds(wave.Delay);

            foreach (Enemy enemy in wave.Enemies)
            {
                _enemiesSpawner.Spawn(enemy);
                yield return new WaitForSeconds(wave.SpawnRate);
            }
        }
    }
}