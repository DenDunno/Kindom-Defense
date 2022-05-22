using UnityEngine;

public class MenuTransitions : MonoBehaviour
{
    [SerializeField] private CameraAnimation _cameraAnimation;
    [SerializeField] private MainMenuButtons _mainMenuButtons;
    [SerializeField] private LevelChoice _levelChoice;
    
    public async void GoToMenu()
    {
        _levelChoice.Hide();
        await _cameraAnimation.GoToMenu();
        _mainMenuButtons.Show();
    }

    public async void GoToLevelChoice()
    {
        _mainMenuButtons.Hide();
        await _cameraAnimation.GoToLevelChoice();
        _levelChoice.Show();
    }
}