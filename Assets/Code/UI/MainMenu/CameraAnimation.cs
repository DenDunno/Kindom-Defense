using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField] private Transform _menu;
    [SerializeField] private Transform _levelChoice;
    private const float _animationDuration = 1.5f;

    public async UniTask GoToMenu()  
    {
        await AnimateCamera(_menu);
    }

    public async UniTask GoToLevelChoice()
    {
        await AnimateCamera(_levelChoice);
    }

    private async UniTask AnimateCamera(Transform target)
    {
        transform.DOMove(target.position, _animationDuration);
        await transform.DORotate(target.rotation.eulerAngles, _animationDuration).AsyncWaitForCompletion();
    }
}