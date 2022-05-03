using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

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
        transform.rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, 0);
    }
}