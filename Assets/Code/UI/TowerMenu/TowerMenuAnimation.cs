using System;
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
    
    public Tween Show()
    {
        _billboard.RotateToCameraNow();
        _menu.gameObject.SetActive(true);
        Tween tween = _menu.DOScale(_targetScale, _showDuration).SetEase(Ease.OutBack);
        tween.onComplete += () => _graphicRaycaster.enabled = true;

        return tween;
    }
    
    public Tween Hide()
    {
        _graphicRaycaster.enabled = false;
        Tween tween = _menu.DOScale(0f, _hideDuration).SetEase(Ease.InBack);
        tween.onComplete += () => _menu.gameObject.SetActive(false);

        return tween;
    }
}