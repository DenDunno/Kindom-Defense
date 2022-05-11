using UnityEngine;

public class LevelChoiceAnimation : MonoBehaviour
{
    [SerializeField] private CameraAnimation _cameraAnimation;
    private const float _duration = 0.7f;
    private const float _delay = 0.3f;

    public async void Play()
    {
        await _cameraAnimation.GoToLevelChoice();
    }
}