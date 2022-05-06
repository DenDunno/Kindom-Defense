using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private TowerModels _towerModels;
    private int _upgradeIndex;
    
    public void Upgrade()
    {
        SetTowerView(++_upgradeIndex);
    }

    public void ReturnStartView()
    {
        SetTowerView(0);
    }

    private void SetTowerView(int upgradeIndex)
    {
        Model model = _towerModels.GetTowerModel(upgradeIndex);
        _meshFilter.mesh = model.Mesh;
        _meshRenderer.material = model.Material;
    }
}