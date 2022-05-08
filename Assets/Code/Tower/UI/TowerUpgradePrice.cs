using TMPro;
using UnityEngine;

public class TowerUpgradePrice : UIState
{
    [SerializeField] private Tower _tower;
    [SerializeField] private TMP_Text _upgradeTextUI;
    [SerializeField] private TMP_Text _sellTextUI;

    private void OnEnable()
    {
        if (_tower.WeaponPresenter.UpgradedWeapon != null)
            _upgradeTextUI.text = _tower.WeaponPresenter.UpgradedWeapon.Price.ToString();
        
        _sellTextUI.text = _tower.WeaponPresenter.SellPrice.ToString();
    }
}