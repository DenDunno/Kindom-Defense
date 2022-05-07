using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TowerMenuAnimation
{
    [SerializeField] private RectTransform _menu;
    [SerializeField] private Billboard _billboard;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;
    private const float _showDuration = 1f;
    private const float _hideDuration = 0.8f;
    private const float _targetScale = 0.01f;
    
    public async UniTask Show()
    {
        _billboard.Update();
        _menu.gameObject.SetActive(true);
        await _menu.DOScale(_targetScale, _showDuration).SetEase(Ease.OutBack).AsyncWaitForCompletion();
        _graphicRaycaster.enabled = true;
    }
    
    public async UniTask Hide()
    {
        _graphicRaycaster.enabled = false;
        await _menu.DOScale(0f, _hideDuration).SetEase(Ease.InBack).AsyncWaitForCompletion();
        _menu.gameObject.SetActive(false);
    }
}