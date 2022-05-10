using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

[Serializable]
public class PlayerStatsUI
{
    [SerializeField] private TMP_Text _goldUI;
    private const float _animationDuration = 0.25f;
    private const float _targetScale = 1.35f;
    private const float _startScale = 1f;
    private Sequence _animation;
    
    public void SetValue(int gold)
    {
        int current = int.Parse(_goldUI.text);
        
        _animation?.Kill();
        _animation = DOTween.Sequence();

        _animation.Append(_goldUI.DOCounter(current, gold, _animationDuration));
        _animation.Join(_goldUI.DOScale(_targetScale, _animationDuration));
        _animation.Append(_goldUI.DOScale(_startScale, _animationDuration));
    }
}