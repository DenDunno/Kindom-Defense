using System;
using TMPro;
using UnityEngine;

[Serializable]
public class Price
{
    [SerializeField] private WeaponPresenter _weaponPresenter;
    [SerializeField] private TMP_Text _priceUI;

    public void SetPrice()
    {
        _priceUI.text = _weaponPresenter.Price.ToString();
    }
}