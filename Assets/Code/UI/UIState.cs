using UnityEngine;

public class UIState : MonoBehaviour
{
    [SerializeField] private UISwitcher _uiSwitcher;

    public void Activate()
    {
        _uiSwitcher.ActivateState(this);
    }
}