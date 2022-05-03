using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    private const float _rotationSpeed = 5f;

    public void Init(Camera mainCamera)
    {
        _mainCamera = mainCamera;
    }
    
    public void Update()
    {
        MoveInFrontOfCamera();
        RotateToCamera();
    }

    private void MoveInFrontOfCamera()
    {
    }

    private void RotateToCamera()
    {
        Quaternion rotation = Quaternion.LookRotation(_mainCamera.transform.position - transform.position, _mainCamera.transform.up);
        rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, 0);
        
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }
}