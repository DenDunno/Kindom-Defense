using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TowerMenuUI
{
    [SerializeField] private Transform _tower;
    [SerializeField] private UIState _upgradeState;
    [SerializeField] private UIState _selectionState;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Transform _detectionRadius;
    
    public void SetUI(bool isSelected)
    {
        var weapon = _tower.GetComponentInChildren<WeaponPresenter>();
        bool hasWeapon = weapon != null;
        UIState uiState = hasWeapon ? _upgradeState : _selectionState;
        
        if (hasWeapon)
        {
            _upgradeButton.gameObject.SetActive(weapon.UpgradedWeapon != null);    
        }
        
        _detectionRadius.gameObject.SetActive(isSelected && hasWeapon);
        
        uiState.Activate();
    }
}