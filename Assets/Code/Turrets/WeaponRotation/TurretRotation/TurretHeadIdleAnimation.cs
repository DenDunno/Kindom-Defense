using UnityEngine;

public class TurretHeadIdleAnimation : IWeaponHeadIdleAnimation
{
    private readonly Transform _transform;
    private const float _animationSpeed = 2f;
    
    public TurretHeadIdleAnimation(Transform transform)
    {
        _transform = transform;
    }
    
    void IWeaponHeadIdleAnimation.Play()
    {
        Vector3 eulerAngles = _transform.eulerAngles;
        
        eulerAngles.x = Mathf.LerpAngle(eulerAngles.x, 0, _animationSpeed * Time.deltaTime);
        
        _transform.rotation = Quaternion.Euler(eulerAngles);
    }
}