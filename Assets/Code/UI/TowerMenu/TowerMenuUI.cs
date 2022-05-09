using System;
using UnityEngine;

[Serializable]
public class TowerMenuUI
{
    [SerializeField] private Tower _tower;
    [SerializeField] private UIState _upgradeState;
    [SerializeField] private UIState _selectionState;
    [SerializeField] private DetectionRadius _detectionRadius;

    public void SetUI(bool isSelected)
    {
        bool hasWeapon = _tower.Weapon != null;
        UIState uiState = hasWeapon ? _upgradeState : _selectionState;
        uiState.Activate();

        _detectionRadius.gameObject.SetActive(isSelected && hasWeapon);
    }
}