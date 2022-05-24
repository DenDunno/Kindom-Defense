using DG.Tweening;
using UnityEngine;

public class LevelChoice : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    private const float _duration = 1f;
    private const float _startYPosition = -1000;
    
    public void Show()
    {
        _rectTransform.DOAnchorPosY(0, _duration).SetEase(Ease.OutBack);
    }
    
    public void Hide()
    {
        _rectTransform.DOAnchorPosY(_startYPosition, _duration);
    }
}