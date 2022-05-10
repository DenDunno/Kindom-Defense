using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveList _waveList;
    [SerializeField] private Kingdom _kingdom;
    [SerializeField] private Camera _mainCamera;
    private EnemiesFactory _enemiesFactory;
    private PlayerGold _playerGold;

    public void Init(EnemiesFactory enemiesFactory, PlayerGold playerGold)
    {
        _enemiesFactory = enemiesFactory;
        _playerGold = playerGold;
    }
    
    private IEnumerator Start()
    {
        for (int i = 0; i < _waveList.Count; i++)
        {
            yield return StartCoroutine(SpawnWave(i));
        }
    }

    private IEnumerator SpawnWave(int waveIndex)
    {
        Wave wave = _waveList[waveIndex];

        foreach (EnemiesGroup enemiesGroup in wave.EnemiesGroups)
        {
            yield return new WaitForSeconds(enemiesGroup.Delay);
            
            foreach (AssetReference enemyReference in enemiesGroup.Enemies)
            {
                Enemy enemy = SpawnEnemy(enemyReference);
                _playerGold.TryAddEnemyToTrack(enemy);
                
                yield return new WaitForSeconds(enemiesGroup.SpawnRate);
            }
        }
    }

    private Enemy SpawnEnemy(AssetReference enemyReference)
    {
        Enemy enemy = _enemiesFactory.Create(enemyReference);
        enemy.Startup.Init(_kingdom.transform, _mainCamera);
        enemy.transform.parent = transform;
        enemy.transform.localPosition = Vector3.zero;

        return enemy;
    }
}