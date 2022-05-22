using UnityEngine;

public class AppStartup : MonoBehaviour
{
    [SerializeField] private MenuTransitions _menuTransitions;
    
    private void Start()
    {
        _menuTransitions.GoToMenu();
    }
}