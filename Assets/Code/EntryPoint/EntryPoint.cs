using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private WaveSpawner[] _waveSpawners;
    [SerializeField] private List<AssetReference> _enemiesUsedInLevel;
    [SerializeField] private PlayerGold _playerGold;
    [SerializeField] private Tower[] _towers;
    private IUpdatable[] _updatables;
    
    private void Start()
    {
        var enemiesFactory = new EnemiesFactory(_enemiesUsedInLevel);
        _updatables = new IUpdatable[] {enemiesFactory};

        enemiesFactory.LoadEnemies();
        _waveSpawners.ForEach(waveSpawner => waveSpawner.Init(enemiesFactory, _playerGold));
        _towers.ForEach(tower => tower.Init(_playerGold));
    }

    private void Update()
    {
        _updatables.ForEach(updatable => updatable.Update());
    }
}