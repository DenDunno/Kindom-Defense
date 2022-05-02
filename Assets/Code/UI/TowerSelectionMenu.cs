using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class TowerSelectionMenu : MonoBehaviour
{
    [SerializeField] private Billboard _billboard;
    private const float _duration = 1f;
    
    public async UniTask Show()
    {
        gameObject.SetActive(true);
        _billboard.Update();
        await transform.DOScale(1f, _duration).SetEase(Ease.OutBack).AsyncWaitForCompletion();
    }
    
    public async UniTask Hide()
    {
        await transform.DOScale(0f, _duration).SetEase(Ease.InBack).AsyncWaitForCompletion();
        gameObject.SetActive(false);
    }
}