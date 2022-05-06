using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenu : MonoBehaviour
{
    [SerializeField] private Billboard _billboard;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;
    private const float _showDuration = 1f;
    private const float _hideDuration = 0.8f;
    private const float _targetScale = 0.01f;
    
    public async UniTask Show()
    {
        _billboard.Update();
        gameObject.SetActive(true);
        await transform.DOScale(_targetScale, _showDuration).SetEase(Ease.OutBack).AsyncWaitForCompletion();
        _graphicRaycaster.enabled = true;
    }
    
    public async UniTask Hide()
    {
        _graphicRaycaster.enabled = false;
        await transform.DOScale(0f, _hideDuration).SetEase(Ease.InBack).AsyncWaitForCompletion();
        gameObject.SetActive(false);
    }
}