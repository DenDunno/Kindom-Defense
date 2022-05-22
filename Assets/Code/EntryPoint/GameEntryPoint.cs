using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private WaveSpawner[] _waveSpawners;
    [SerializeField] private GamePools _gamePools;
    [SerializeField] private PlayerGold _playerGold;
    [SerializeField] private Tower[] _towers;
    [SerializeField] private TradeButtons[] _tradeButtons;
    [SerializeField] private TurretBuilding _turretBuilding;
    private IUpdatable[] _updatables;
    
    private void Start()
    {
        _updatables = new IUpdatable[] {_gamePools};

        _gamePools.Init();
        _turretBuilding.Init(_gamePools);
        _playerGold.Init();
        _waveSpawners.ForEach(waveSpawner => waveSpawner.Init(_gamePools.EnemiesFactory, _playerGold));
        _towers.ForEach(tower => tower.Init(_playerGold, _turretBuilding));
        _tradeButtons.ForEach(tradeButtons => tradeButtons.Init(_playerGold));
    }

    private void Update()
    {
        _updatables.ForEach(updatable => updatable.Update());
    }
}