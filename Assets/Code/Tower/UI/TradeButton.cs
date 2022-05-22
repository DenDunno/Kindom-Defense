using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TradeButton
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TMP_Text _priceUI;
    [SerializeField] private Button _button;

    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }
    
    public void SetPrice()
    {
        SetPrice(_weapon.Settings.Price);
    }
    
    public void SetPrice(int gold)
    {
        _priceUI.text = gold.ToString();
    }

    public void SetInteractable(float currentGold)
    {
        _button.interactable = _weapon.Settings.Price <= currentGold;
    }

    public void SetActive(bool activate)
    {
        _button.gameObject.SetActive(activate);
    }
}