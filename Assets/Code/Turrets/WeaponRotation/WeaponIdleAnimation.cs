using UnityEngine;

public class WeaponIdleAnimation : IUpdatable
{
    private readonly Transform _pillar;
    private readonly IWeaponHeadIdleAnimation _weaponHeadIdleAnimation;
    private const float _rotationSpeed = 12f;

    public WeaponIdleAnimation(Transform pillar, IWeaponHeadIdleAnimation weaponHeadIdleAnimation)
    {
        _pillar = pillar;
        _weaponHeadIdleAnimation = weaponHeadIdleAnimation;
    }
    
    void IUpdatable.Update()
    {
        Play();
        _weaponHeadIdleAnimation.Play();
    }

    private void Play()
    {
        _pillar.rotation *= Quaternion.Euler(0, _rotationSpeed * Time.deltaTime, 0); 
    }
}