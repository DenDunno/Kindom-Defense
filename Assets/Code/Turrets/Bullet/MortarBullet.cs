using UnityEngine;

public class MortarBullet : Bullet
{
    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    private float _heightOffset;
    private float _startVelocity;
    private float _flyTime;
    private float _time;
    private const float _g = 9.81f;

    public override void Init(Transform target)
    {
        _targetPosition = target.position;
        _startPosition = transform.position;
        _heightOffset = EvaluateHeightOffset();
        _startVelocity = EvaluateStartVelocity();
        _flyTime = EvaluateFlyTime();
        _time = 0;
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

    private void Update()
    {
        _time += Time.deltaTime;
        
        Vector3 newPosition = Vector3.LerpUnclamped(_startPosition, _targetPosition, _time / _flyTime);
        newPosition.y = EvaluateHeight();

        transform.position = newPosition;
    }

    private float EvaluateHeight()
    {
        return _startPosition.y + _startVelocity * _time - _g * _time * _time / 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is TerrainCollider)
        {
            ToggleBullet(false);
        }
    }
}