using System.Collections.Generic;
using UnityEngine;

public class TradeButtons : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private List<TradeButton> _selectionButtons;
    [SerializeField] private TradeButton _upgradeButton;
    [SerializeField] private TradeButton _sellButton;
    private List<TradeButton> _buttonsToUpdate = new List<TradeButton>();
    private PlayerGold _playerGold;
    
    public void Init(PlayerGold playerGold)
    {
        _playerGold = playerGold;
    }
    
    private void OnEnable()
    {
        _buttonsToUpdate = new List<TradeButton>();
        
        if (_tower.Weapon != null)
        {
            _upgradeButton.SetWeapon(_tower.Weapon.Settings.UpgradedWeapon);
            _sellButton.SetPrice(_tower.Weapon.Settings.SellPrice);

            bool hasUpgrade = _tower.Weapon.Settings.HasUpgrade;
            _upgradeButton.SetActive(hasUpgrade);
            
            if (hasUpgrade)
            {
                _upgradeButton.SetPrice();
                _buttonsToUpdate = new List<TradeButton>() {_upgradeButton};
            }
        }
        else
        {
            _buttonsToUpdate = _selectionButtons;
            _selectionButtons.ForEach(button => button.SetPrice());
        }
    }

    private void Update()
    {
        foreach (TradeButton tradeButton in _buttonsToUpdate)
        {
            tradeButton.SetInteractable(_playerGold.Value);
        }
    }
}