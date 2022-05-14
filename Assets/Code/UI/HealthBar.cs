using DG.Tweening;
using MPUIKIT;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Billboard _healthBar;
    [SerializeField] private Slider _slider;
    [SerializeField] private MPImage _healthBarView;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Billboard _billboard;
    [SerializeField] private Health _enemyHealth;
    private const float _animationDuration = 0.25f;
    private Tween _animation;

    private void OnEnable()
    {
        _enemyHealth.DamageTaken += UpdateValue;
    }
    
    private void OnDisable()
    {
        _enemyHealth.DamageTaken -= UpdateValue;
    }

    private void UpdateValue(float current, float max)
    {
        if (_healthBar.gameObject.activeInHierarchy == false)
        {
            _healthBar.gameObject.SetActive(true);
            _billboard.RotateToCameraNow();
        }

        if (current <= 0)
        {
            _healthBar.gameObject.SetActive(false);
            return;
        }
        
        _animation?.Kill();
        _animation = DOTween.To(() => _slider.value, SetValue, current / max, _animationDuration);
    }

    private void SetValue(float sliderValue)
    {
        _slider.value = sliderValue;
        _healthBarView.color = _gradient.Evaluate(sliderValue);
    }
    
    public void ResetHealthBar()
    {
        SetValue(1);
        _healthBar.gameObject.SetActive(false);
    }
}