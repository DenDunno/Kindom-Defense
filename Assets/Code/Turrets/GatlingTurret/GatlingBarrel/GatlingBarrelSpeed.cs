using UnityEngine;

public class GatlingBarrelSpeed : IUpdatable
{
    private readonly TowerRadar _towerRadar;
    private const float _targetRotationSpeed = 900f;
    private const float _acceleration = 800f;

    public GatlingBarrelSpeed(TowerRadar towerRadar)
    {
        _towerRadar = towerRadar;
    }

    public float Value { get; private set; }
    public bool IsAccelerating { get; private set; }
    public float SpeedRatio => Value / _targetRotationSpeed;

    void IUpdatable.Update()
    {
        if (_towerRadar.HasTarget)
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