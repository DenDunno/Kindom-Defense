using UnityEngine;
using Random = UnityEngine.Random;

public class MortarBulletRotation : MonoBehaviour
{
    private Vector3 _rotationVector;
    private const float _speed = 500f;
    
    private void OnEnable()
    {
        _rotationVector = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)).normalized;
    }

    private void Update()
    {
        transform.Rotate(_rotationVector * (_speed * Time.deltaTime));
    }
}