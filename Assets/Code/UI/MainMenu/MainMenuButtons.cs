using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    private const float _duration = 0.7f;
    private const float _delay = 0.3f;
    private const float _startXPosition = -600;
    
    public async void Show()
    {
        await AnimateButtons(_buttons, 0, Ease.OutBack);
    }
    
    public async void Hide()
    {
        await AnimateButtons(_buttons.Reverse(), _startXPosition, Ease.InBack);
    }

    private async UniTask AnimateButtons(IEnumerable<Button> buttons, float targetPosition, Ease ease)
    {
        foreach (Button button in buttons)
        {
            (button.transform as RectTransform).DOAnchorPosX(targetPosition, _duration).SetEase(ease);
            await UniTask.Delay(TimeSpan.FromSeconds(_delay));
        }
    }
}