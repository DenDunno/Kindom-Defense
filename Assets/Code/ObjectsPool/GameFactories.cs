using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class GameFactories : IUpdatable
{
    [SerializeField] private List<AssetReference> _enemiesUsedInLevel;
    [SerializeField] private MortarBullet _mortarBulletPrefab;
    [SerializeField] private GatlingBullet _gatlingBulletPrefab;
    
    public EnemiesFactory EnemiesFactory { get; private set; }
    public ObjectFactory<Bullet> MortarBulletFactory { get; private set; }
    public ObjectFactory<Bullet> GatlingBulletFactory { get; private set; }
    private IUpdatable[] _factories;
    
    public void Init()
    {
        EnemiesFactory = new EnemiesFactory(_enemiesUsedInLevel);
        MortarBulletFactory = new ObjectFactory<Bullet>(_mortarBulletPrefab);
        GatlingBulletFactory = new ObjectFactory<Bullet>(_gatlingBulletPrefab);
        _factories = new IUpdatable[] {EnemiesFactory, MortarBulletFactory, GatlingBulletFactory};
        EnemiesFactory.LoadEnemies();
    }

    void IUpdatable.Update()  
    {
        _factories.UpdateForEach();
    }
}