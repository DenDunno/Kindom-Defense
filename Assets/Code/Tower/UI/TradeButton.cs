using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TradeButton
{
    [SerializeField] private WeaponPresenter _weaponPresenter;
    [SerializeField] private TMP_Text _priceUI;
    [SerializeField] private Button _button;

    public void SetWeapon(WeaponPresenter weaponPresenter)
    {
        _weaponPresenter = weaponPresenter;
    }
    
    public void SetPrice()
    {
        SetPrice(_weaponPresenter.Price);
    }
    
    public void SetPrice(int gold)
    {
        _priceUI.text = gold.ToString();
    }

    public void SetInteractable(float currentGold)
    {
        _button.interactable = _weaponPresenter.Price <= currentGold;
    }

    public void SetActive(bool activate)
    {
        _button.gameObject.SetActive(activate);
    }
}