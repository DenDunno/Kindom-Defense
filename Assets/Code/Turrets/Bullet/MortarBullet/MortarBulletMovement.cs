using UnityEngine;
using UnityEngine.AI;

public class MortarBulletMovement
{
    private readonly Vector3 _startPosition;
    private readonly Transform _target;
    private readonly float _speed;
    private Vector3 _targetPosition;
    private float _heightOffset;
    private float _startVelocity;
    private float _flyTime;
    private float _time;

    public MortarBulletMovement(Transform target, Vector3 startPosition, float speed)
    {
        _target = target;
        _speed = speed;
        _startPosition = startPosition;
    }

    public bool DestinationReached { get; private set; }

    public void EvaluatePath()
    {
        EvaluatePath(_target.position);
        
        float enemySpeed = _target.GetComponent<NavMeshAgent>().speed;
        float enemyOffset = _flyTime * enemySpeed;
        
        EvaluatePath(_target.position +  enemyOffset * _target.forward);
    }
    
    private void EvaluatePath(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        _heightOffset = EvaluateHeightOffset();
        _startVelocity = EvaluateStartVelocity();
        _flyTime = EvaluateFlyTime();
    }

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