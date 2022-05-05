using DG.Tweening;
using MPUIKIT;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private MPImage _healthBarView;
    [SerializeField] private Gradient _gradient;
    private const float _animationDuration = 0.25f;
    private Tween _animation; 

    public void UpdateValue(float sliderValue)
    {
        if (gameObject.activeInHierarchy == false)
        {
            gameObject.SetActive(true);
        }

        if (sliderValue <= 0)
        {
            gameObject.SetActive(false);
            return;
        }
        
        _animation?.Kill();
        _animation = DOTween.To(() => _slider.value, SetValue, sliderValue, _animationDuration);
    }

    private void SetValue(float sliderValue)
    {
        _slider.value = sliderValue;
        _healthBarView.color = _gradient.Evaluate(sliderValue);
    }
}