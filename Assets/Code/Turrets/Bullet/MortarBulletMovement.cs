using UnityEngine;

public class MortarBulletMovement
{
    private readonly Vector3 _targetPosition;
    private readonly Vector3 _startPosition;
    private readonly float _speed;
    private readonly float _heightOffset;
    private readonly float _startVelocity;
    private readonly float _flyTime;
    private const float _g = 9.81f;
    private float _time;

    public MortarBulletMovement(Vector3 targetPosition, Vector3 startPosition, float speed)
    {
        _targetPosition = targetPosition;
        _startPosition = startPosition;
        _speed = speed;
        _heightOffset = EvaluateHeightOffset();
        _startVelocity = EvaluateStartVelocity();
        _flyTime = EvaluateFlyTime();
    }

    public Vector3 EvaluatePosition()
    {
        _time += Time.deltaTime * _speed;
        
        Vector3 newPosition = Vector3.LerpUnclamped(_startPosition, _targetPosition, _time / _flyTime);
        newPosition.y = _startPosition.y + _startVelocity * _time - _g * _time * _time / 2;

        return newPosition;
    }

    private float EvaluateHeightOffset()
    {
        var startPosition = new Vector2(_startPosition.x, _startPosition.z);
        var targetPosition = new Vector2(_targetPosition.x, _targetPosition.z);
        float distance = Vector2.Distance(startPosition, targetPosition);

        return 0.16f * distance + 0.83f;
    }

    private float EvaluateStartVelocity()
    {
        float tMax = Mathf.Sqrt(_heightOffset * 2 / _g);
        return (_heightOffset + _g * tMax * tMax / 2) / tMax;
    }

    private float EvaluateFlyTime()
    {
        float a = -_g / 2;
        float b = _startVelocity;
        float c = _startPosition.y - _targetPosition.y;
        float discriminant = b * b - 4 * a * c;
        return (-b - Mathf.Sqrt(discriminant)) / (2 * a);
    }
}