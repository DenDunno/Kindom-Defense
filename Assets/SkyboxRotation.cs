using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    [SerializeField] private Material _skybox;
    private const float _speed = 0.5f;
    private int _rotationPropertyId;
    private float _angle;
    
    private void Start()
    {
        _rotationPropertyId = Shader.PropertyToID("_Rotation");
    }

    private void Update()
    {
        _angle += _speed * Time.deltaTime;

        if (_angle > 360)
            _angle = 0;
        
        _skybox.SetFloat(_rotationPropertyId, _angle);
    }
}