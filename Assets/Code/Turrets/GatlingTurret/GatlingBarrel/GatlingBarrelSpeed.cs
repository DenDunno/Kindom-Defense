using UnityEngine;

public class GatlingBarrelSpeed : IUpdatable
{
    private readonly WeaponRadar _weaponRadar;
    private const float _targetRotationSpeed = 900f;
    private const float _acceleration = 700f;

    public GatlingBarrelSpeed(WeaponRadar weaponRadar)
    {
        _weaponRadar = weaponRadar;
    }

    public float Value { get; private set; }
    public bool IsAccelerating { get; private set; }
    public float SpeedRatio => Value / _targetRotationSpeed;

    void IUpdatable.Update()
    {
        if (_weaponRadar.HasTarget)
        {
            TryAddAcceleration(Value < _targetRotationSpeed, _acceleration);
        }
        else
        {
            TryAddAcceleration(Value > 0, -_acceleration);
        }
    }
    
    private void TryAddAcceleration(bool condition, float acceleration)
    {
        IsAccelerating = condition;
        
        if (IsAccelerating)
        {
            Value += acceleration * Time.deltaTime;
        }
    }
}