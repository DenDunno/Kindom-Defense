using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TurretBuilding
{
    [SerializeField] private List<GatlingTurret> _gatlingTurrets;
    [SerializeField] private List<Turret> _mortars;
    private Dictionary<Weapon, IFactory<Weapon>> _weaponFactories = new Dictionary<Weapon, IFactory<Weapon>>();
    
    public void Init(GameFactories gameFactories)
    {
        _gatlingTurrets.ForEach(turret => CreateTurretFactory(turret, gameFactories.GatlingBulletFactory));
        _mortars.ForEach(mortar => CreateTurretFactory(mortar, gameFactories.MortarBulletFactory));
    }

    private void CreateTurretFactory(Turret turret, IFactory<Bullet> bulletFactory)
    {
        _weaponFactories[turret] = new TurretFactory(new SimpleFactory<Turret>(turret), bulletFactory);
    }
    
    public Weapon Build(Weapon prefab)
    {
        return _weaponFactories[prefab].Create();
    }
}