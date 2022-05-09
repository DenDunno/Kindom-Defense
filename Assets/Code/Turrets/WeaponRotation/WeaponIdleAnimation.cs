using UnityEngine;

public class WeaponIdleAnimation : IUpdatable
{
    private readonly float _targetAngle;
    private readonly Transform _pillar;
    private readonly Transform _head;
    private const float _pillarRotationSpeed = 12f;
    private const float _headRotationSpeed = 4f;

    public WeaponIdleAnimation(Transform pillar, Transform head, float targetAngle)
    {
        _targetAngle = targetAngle;
        _pillar = pillar;
        _head = head;
    }
    
    void IUpdatable.Update()
    {
        RotatePillar();
        RotateHead();
    }

    private void RotatePillar()
    {
        _pillar.rotation *= Quaternion.Euler(0, _pillarRotationSpeed * Time.deltaTime, 0);
    }

    private void RotateHead()
    {
        Vector3 eulerAngles = _head.eulerAngles;
        
        eulerAngles.x = Mathf.LerpAngle(eulerAngles.x, _targetAngle, _headRotationSpeed * Time.deltaTime);
        
        _head.rotation = Quaternion.Euler(eulerAngles);
    }
}