using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveList _waveList;
    [SerializeField] private Kingdom _kingdom;
    private Queue<Wave> _waves;
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
            Wave wave = _waves.Dequeue();

            yield return new WaitForSeconds(wave.Delay);

            foreach (AssetReference enemyReference in wave.Enemies)
            {
                _enemiesSpawner.Spawn(enemyReference);
                yield return new WaitForSeconds(wave.SpawnRate);
            }
        }
    }
}