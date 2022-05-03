using DG.Tweening;
using MPUIKIT;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private MPImage _healthBarView;
    private const float _animationDuration = 0.25f;
    private Tween _animation;

    private void OnEnable()
    {
        _enemyHealth.DamageTaken += OnDamageTaken;
    }
    
    private void OnDisable()
    {
        _enemyHealth.DamageTaken -= OnDamageTaken;
    }

    private void OnDamageTaken(float sliderValue)
    {
        _animation?.Kill();
        _animation = DOTween.To(() => _slider.value, SetValue, sliderValue, _animationDuration);
    }

    private void SetValue(float sliderValue)
    {
        _slider.value = sliderValue;
        sliderValue = 1 - sliderValue;
        
        if (sliderValue < 0.5f)
        {
            LerpHealthColor(Color.green, Color.yellow, sliderValue );
        }
        else
        {
            LerpHealthColor(Color.yellow, Color.red, sliderValue - 0.5f);
        }
    }

    private void LerpHealthColor(Color from, Color to, float sliderValue)
    {
        _healthBarView.color = Color.Lerp(from, to, 2 * sliderValue);
    }
}