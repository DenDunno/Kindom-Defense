using System;
using Cysharp.Threading.Tasks;
using EPOOutline;
using UnityEngine;

public class TowerBaseSelection : MonoBehaviour
{
    [SerializeField] private TowerSelectionMenu _selectionMenu;
    [SerializeField] private Outlinable _outlinable;
    private bool _isAnimation;
    
    public bool IsSelected { get; private set; }

    public void Select()
    {
        ToggleSelection(_selectionMenu.Show, false);
    }
    
    public void Unselect()
    {
        ToggleSelection(_selectionMenu.Hide, true);
    }
    
    private async void ToggleSelection(Func<UniTask> tween, bool isSelected)
    {
        if (IsSelected == isSelected && _isAnimation == false)
        {
            IsSelected = !isSelected;
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