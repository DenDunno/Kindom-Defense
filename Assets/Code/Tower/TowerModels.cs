using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerModels", menuName = "ScriptableObjects/TowerModels", order = 2)]
public class TowerModels : ScriptableObject
{
    [SerializeField] private List<Model> _towerModels;

    public Model GetTowerModel(int index)
    {
        return _towerModels[index];
    }
}