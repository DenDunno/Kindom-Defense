using System;
using UnityEngine;

[Serializable]
public class TowerUpgrade 
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private TowerModels _towerModels;
    private int _upgradeIndex;
    
    public void Upgrade()
    {
        SetTowerView(_upgradeIndex + 1);
    }

    public void ReturnStartView()
    {
        SetTowerView(0);
    }

    private void SetTowerView(int upgradeIndex)
    {
        _upgradeIndex = upgradeIndex;
        Model model = _towerModels.GetTowerModel(upgradeIndex);
        _meshFilter.mesh = model.Mesh;
        _meshRenderer.material = model.Material;
    }
}