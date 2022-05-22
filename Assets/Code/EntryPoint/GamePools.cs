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
    [SerializeField] private Particle _mortarBulletTrailPrefab;
    
    public EnemiesFactory EnemiesFactory { get; private set; }
    public IFactory<MortarBullet> MortarBulletPool { get; private set; }
    public IFactory<GatlingBullet> GatlingBulletPool { get; private set; }
    public IFactory<Particle> ExplosionsPool { get; private set; }
    public IFactory<Particle> MortarBulletTrailPool { get; private set; }
    private IUpdatable[] _factories;
    
    public void Init()
    {
        var mortarBulletPool = new ObjectPool<MortarBullet>(_mortarBulletPrefab);
        var gatlingBulletPool = new ObjectPool<GatlingBullet>(_gatlingBulletPrefab);
        var explosionsPool = new ObjectPool<Particle>(_explosionPrefab);
        var mortarBulletTrailPool = new ObjectPool<Particle>(_mortarBulletTrailPrefab);
        
        EnemiesFactory = new EnemiesFactory(_enemiesUsedInLevel);
        MortarBulletPool = mortarBulletPool;
        GatlingBulletPool = gatlingBulletPool;
        ExplosionsPool = explosionsPool;
        MortarBulletTrailPool = mortarBulletTrailPool;
        
        _factories = new IUpdatable[]
            {EnemiesFactory, mortarBulletPool, gatlingBulletPool, explosionsPool, mortarBulletTrailPool};
        
        EnemiesFactory.LoadEnemies();
    }

    void IUpdatable.Update()  
    {
        _factories.UpdateForEach();
    }
}