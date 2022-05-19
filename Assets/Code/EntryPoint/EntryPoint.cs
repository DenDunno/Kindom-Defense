using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private WaveSpawner[] _waveSpawners;
    [SerializeField] private GameFactories _gameFactories;
    [SerializeField] private PlayerGold _playerGold;
    [SerializeField] private Tower[] _towers;
    [SerializeField] private TradeButtons[] _tradeButtons;
    [SerializeField] private TurretBuilding _turretBuilding;
    private IUpdatable[] _updatables;
    
    private void Start()
    {
        _updatables = new IUpdatable[] {_gameFactories};

        _gameFactories.Init();
        _turretBuilding.Init(_gameFactories);
        _playerGold.Init();
        _waveSpawners.ForEach(waveSpawner => waveSpawner.Init(_gameFactories.EnemiesFactory, _playerGold));
        _towers.ForEach(tower => tower.Init(_playerGold, _turretBuilding));
        _tradeButtons.ForEach(tradeButtons => tradeButtons.Init(_playerGold));
    }

    private void Update()
    {
        _updatables.ForEach(updatable => updatable.Update());
    }
}