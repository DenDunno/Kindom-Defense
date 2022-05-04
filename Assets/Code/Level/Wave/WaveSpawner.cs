using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveList _waveList;
    [SerializeField] private Kingdom _kingdom;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private EnemiesFactory _enemiesFactory;
    private Queue<Wave> _waves;
    
    private IEnumerator Start()
    {
        _waves = _waveList.Waves;

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
                SpawnEnemy(enemyReference);
                yield return new WaitForSeconds(wave.SpawnRate);
            }
        }
    }

    private void SpawnEnemy(AssetReference enemyReference)
    {
        Enemy enemy = _enemiesFactory.Create(enemyReference);
        enemy.transform.parent = transform;
        enemy.transform.localPosition = Vector3.zero;
        
        var enemyStartup = enemy.GetComponent<EnemyStartup>();
        enemyStartup.Init(_kingdom.transform, _mainCamera);
    }
}