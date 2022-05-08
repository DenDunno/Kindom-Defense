using System.Collections.Generic;
using UnityEngine;

public class TowerSelectionPrice : UIState
{
    [SerializeField] private List<Price> _prices;

    private void OnEnable()
    {
        foreach (Price price in _prices)
        {
            price.SetPrice();
        }
    }
}