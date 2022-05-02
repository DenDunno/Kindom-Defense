using UnityEngine;

public class GatlingTurretSpinning : MonoBehaviour
{
    [SerializeField] private TowerRadar _towerRadar;
    private const float _targetRotationSpeed = 900f;
    private const float _acceleration = 800f;
    private float _currentSpeed;
    
    public bool ReadyForShooting => _currentSpeed >= _targetRotationSpeed;

    private void Update()
    {
        ChangeRotationSpeed();
        RotateHead();
    }

    private void ChangeRotationSpeed()
    {
        if (_towerRadar.HasTarget)
        {
            if (_currentSpeed < _targetRotationSpeed)
            {
                AddAcceleration(_acceleration);
            }
        }
        else
        {
            if (_currentSpeed > 0)
            {
                AddAcceleration(-_acceleration);
            }
        }
    }
    
    private void AddAcceleration(float acceleration)
    {
        _currentSpeed += acceleration * Time.deltaTime;
    }

    private void RotateHead()
    {
        transform.rotation *= Quaternion.Euler(0, 0, _currentSpeed * Time.deltaTime);
    }
}