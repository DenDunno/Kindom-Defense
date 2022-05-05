using UnityEngine;

public class TurretIdleAnimation : IUpdatable 
{
    private readonly Transform _transform;
    private const float _yRotationSpeed = 20f;
    private const float _xRotationSpeed = 2f;
    
    public TurretIdleAnimation(Transform transform)
    {
        _transform = transform;
    }
    
    void IUpdatable.Update()
    {
        Vector3 eulerAngles = _transform.eulerAngles;
        
        eulerAngles.x = Mathf.LerpAngle(eulerAngles.x, 0, _xRotationSpeed * Time.deltaTime);
        eulerAngles.y += _yRotationSpeed * Time.deltaTime;
        
        _transform.rotation = Quaternion.Euler(eulerAngles);
    }
}