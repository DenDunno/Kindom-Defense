using DG.Tweening;
using UnityEngine;

public class WaveStart : MonoBehaviour
{
    [SerializeField] private RectTransform _playButton;
    [SerializeField] private RectTransform _waveInfoSlider;
    [SerializeField] private Music _music;
    [SerializeField] private WaveSpawner[] _waveSpawners;
    [SerializeField] private WaveInfo _waveInfo;
    private const float _animationDuration = 1f;
        
    public void Play()
    {
        _music.PlayBattle();
        
        foreach (WaveSpawner spawner in _waveSpawners)
        {
            StartCoroutine(spawner.StartWave());
        }

        StartCoroutine(_waveInfo.StartCountDown());

        _playButton.DOScale(0, _animationDuration).SetEase(Ease.InBack).onComplete += () =>
        {
            _playButton.gameObject.SetActive(false);
            _waveInfoSlider.gameObject.SetActive(true);
            _waveInfoSlider.DOScale(1, _animationDuration).SetEase(Ease.OutBack);
        };
    }
}