using System;
using Cysharp.Threading.Tasks;
using EPOOutline;
using UnityEngine;

public class TowerSelection : MonoBehaviour
{
    [SerializeField] private TowerMenu _selectionMenu;
    [SerializeField] private TowerMenu _upgradeMenu;
    [SerializeField] private Tower _tower;
    [SerializeField] private Outlinable _outlinable;
    [SerializeField] private Transform _detectionRadius;
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
            TowerMenu towerMenu;
            
            if (_tower.HasWeapon)
            {
                float detectionRadius = _tower.Weapon.GetComponent<WeaponRadar>().DetectionRadius;
                _detectionRadius.localScale = Vector3.one * detectionRadius * 2;
                _detectionRadius.gameObject.SetActive(show);
                towerMenu = _upgradeMenu;
            }
            else
            {
                towerMenu = _selectionMenu;
            }
            
            Func<UniTask> tween = show ? (Func<UniTask>)towerMenu.Show : towerMenu.Hide;

            IsSelected = !IsSelected;
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