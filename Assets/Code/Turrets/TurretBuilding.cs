using UnityEngine;

public class TurretBuilding
{
    private readonly GameFactories _gameFactories;

    public TurretBuilding(GameFactories gameFactories)
    {
        _gameFactories = gameFactories;
    }
    
    public Weapon Build(Weapon prefab, Transform buildPosition)
    {
        return null;
    }
}