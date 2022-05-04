using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class TowerSelectionMenu : MonoBehaviour
{
    [SerializeField] private Billboard _billboard;
    private const float _showDuration = 1f;
    private const float _hideDuration = 0.8f;
    private const float _targetScale = 0.01f;
    
    public async UniTask Show()
    {
        gameObject.SetActive(true);
        _billboard.Update();
        await transform.DOScale(_targetScale, _showDuration).SetEase(Ease.OutBack).AsyncWaitForCompletion();
    }
    
    public async UniTask Hide()
    {
        await transform.DOScale(0f, _hideDuration).SetEase(Ease.InBack).AsyncWaitForCompletion();
        gameObject.SetActive(false);
    }
}