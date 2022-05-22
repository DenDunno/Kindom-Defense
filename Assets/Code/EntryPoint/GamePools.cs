using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class GamePools : IUpdatable
{
    [SerializeField] private List<AssetReference> _enemiesUsedInLevel;
    [SerializeField] private MortarBullet _mortarBulletPrefab;
    [SerializeField] private GatlingBullet _gatlingBulletPrefab;
    [SerializeField] private Particle _explosionPrefab;
    
    public EnemiesFactory EnemiesFactory { get; private set; }
    public IFactory<MortarBullet> MortarPool { get; private set; }
    public IFactory<GatlingBullet> GatlingBulletPool { get; private set; }
    public IFactory<Particle> ExplosionsPool { get; private set; }
    private IUpdatable[] _factories;
    
    public void Init()
    {
        var mortarBulletPool = new ObjectPool<MortarBullet>(_mortarBulletPrefab);
        var gatlingBulletPool = new ObjectPool<GatlingBullet>(_gatlingBulletPrefab);
        var explosionsPool = new ObjectPool<Particle>(_explosionPrefab);
        
        EnemiesFactory = new EnemiesFactory(_enemiesUsedInLevel);
        MortarPool = mortarBulletPool;
        GatlingBulletPool = gatlingBulletPool;
        ExplosionsPool = explosionsPool;
        
        _factories = new IUpdatable[] {mortarBulletPool, gatlingBulletPool, explosionsPool, EnemiesFactory};
        
        EnemiesFactory.LoadEnemies();
    }

    void IUpdatable.Update()  
    {
        _factories.UpdateForEach();
    }
}