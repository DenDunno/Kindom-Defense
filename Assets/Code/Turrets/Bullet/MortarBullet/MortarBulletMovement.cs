using UnityEngine;

public class MortarBulletMovement
{
    private readonly Vector3 _targetPosition;
    private readonly Vector3 _startPosition;
    private readonly float _speed;
    private readonly float _heightOffset;
    private readonly float _startVelocity;
    private readonly float _flyTime;
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

    public bool DestinationReached { get; private set; }

    public Vector3 EvaluatePosition()
    {
        _time += Time.deltaTime * _speed;
        
        Vector3 newPosition = Vector3.LerpUnclamped(_startPosition, _targetPosition, _time / _flyTime);
        newPosition.y = _startPosition.y + _startVelocity * _time - PhysicsConst.G * _time * _time / 2;

        DestinationReached = _time > _flyTime;

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
        float tMax = Mathf.Sqrt(_heightOffset * 2 / PhysicsConst.G);
        return (_heightOffset + PhysicsConst.G * tMax * tMax / 2) / tMax;
    }

    private float EvaluateFlyTime()
    {
        float a = -PhysicsConst.G / 2;
        float b = _startVelocity;
        float c = _startPosition.y - _targetPosition.y;
        float discriminant = b * b - 4 * a * c;
        return (-b - Mathf.Sqrt(discriminant)) / (2 * a);
    }
}