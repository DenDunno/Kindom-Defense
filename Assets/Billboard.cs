using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _mainCamera;
    private Quaternion _startRotation;
    
    private void Start()
    {
        _mainCamera = Camera.main;
        _startRotation = _mainCamera!.transform.rotation;
    }

    private void Update()
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
        transform.rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, 0);
    }
}