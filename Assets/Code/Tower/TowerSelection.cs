using DG.Tweening;
using EPOOutline;
using UnityEngine;

public class TowerSelection : MonoBehaviour
{
    [SerializeField] private TowerMenuAnimation _menuAnimation;
    [SerializeField] private Outlinable _outlinable;
    [SerializeField] private TowerMenuUI _menuUI;
    private Tween _animation;

    public bool IsSelected { get; private set; }

    public void Select()
    {
        ToggleSelection(true);
    }
    
    public void Unselect()
    {
        ToggleSelection(false);
    }
    
    private void ToggleSelection(bool show)
    {
        if (IsSelected == !show && _animation.IsActive() == false)
        {
            _animation = show ? _menuAnimation.Show() : _menuAnimation.Hide();
            IsSelected = !IsSelected;
            
            _menuUI.SetUI(IsSelected);
            _outlinable.enabled = IsSelected;
        }
    }
}