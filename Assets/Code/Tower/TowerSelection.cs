using System;
using Cysharp.Threading.Tasks;
using EPOOutline;
using UnityEngine;

[Serializable]
public class TowerSelection 
{
    [SerializeField] private TowerMenu _menu;
    [SerializeField] private Transform _detectionRadius;
    [SerializeField] private Outlinable _outlinable;
    private bool _isAnimation;

    public bool IsSelected { get; private set; }

    public void Select()
    {
        ToggleSelection(true);
    }
    
    public void Unselect()
    {
        ToggleSelection(false);
    }
    
    private async void ToggleSelection(bool show)
    {
        if (IsSelected == !show && _isAnimation == false)
        {
            Func<UniTask> tween = show ? (Func<UniTask>)_menu.Show : _menu.Hide;
            IsSelected = !IsSelected;

            _menu.SetUI(IsSelected);
            _outlinable.enabled = IsSelected;
            
            await PlayAnimation(tween);
        }
    }

    private async UniTask PlayAnimation(Func<UniTask> tween)
    {
        _isAnimation = true;
        await tween();
        _isAnimation = false;
    }
}