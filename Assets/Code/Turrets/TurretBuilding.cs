using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TurretBuilding
{
    [SerializeField] private List<GatlingTurret> _gatlingTurrets;
    [SerializeField] private List<Mortar> _mortars;
    private Dictionary<Weapon, IFactory<Weapon>> _weaponFactories = new();
    
    public void Init(GamePools gamePools)
    {
        CreateTurretFactories(_gatlingTurrets, gamePools.GatlingBulletPool, new GatlingBulletInitialization());
        CreateTurretFactories(_mortars, gamePools.MortarPool, new MortarBulletInitialization(gamePools.ExplosionsPool));
    }

    private void CreateTurretFactories(IEnumerable<Turret> turrets, IFactory<Bullet> bulletPool, IBulletInitialization bulletInitialization)
    {
        foreach (Turret turret in turrets)
        {
            _weaponFactories[turret] = new TurretFactory(new SimpleFactory<Turret>(turret), bulletPool, bulletInitialization);
        }
    }
    
    public Weapon Build(Weapon prefab)
    {
        return _weaponFactories[prefab].Create();
    }
}