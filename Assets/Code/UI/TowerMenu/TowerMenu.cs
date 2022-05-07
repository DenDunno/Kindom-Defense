using Cysharp.Threading.Tasks;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    [SerializeField] private TowerMenuAnimation _towerMenuAnimation;
    [SerializeField] private TowerMenuUI _towerMenuUI;
    
    public async UniTask Show() => await _towerMenuAnimation.Show();
    
    public async UniTask Hide() => await _towerMenuAnimation.Hide();

    public void SetUI(bool isSelected) => _towerMenuUI.SetUI(isSelected);
}