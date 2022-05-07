using System.Collections.Generic;
using UnityEngine;

public class UISwitcher : MonoBehaviour
{
    [SerializeField] private List<UIState> _uiStates;

    public void ActivateState(UIState stateToBeActivated)
    {
        _uiStates.ForEach(state => state.gameObject.SetActive(false));
        
        stateToBeActivated.gameObject.SetActive(true);
    }
}