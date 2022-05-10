using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuAnimation : MonoBehaviour
{
    [SerializeField] private PathAnimation _pathAnimation;
    [SerializeField] private Button[] _buttons;
    private const float _duration = 0.7f;
    private const float _delay = 0.3f;

    private void OnEnable()
    {
        _pathAnimation.Finished += Show;
    }
    
    private void OnDisable()
    {
        _pathAnimation.Finished -= Show;
    }

    private async void Show()
    {
        foreach (Button button in _buttons)
        {
            (button.transform as RectTransform).DOAnchorPosX(0, _duration).SetEase(Ease.OutBack);
            await UniTask.Delay(TimeSpan.FromSeconds(_delay));
        }
    }
}