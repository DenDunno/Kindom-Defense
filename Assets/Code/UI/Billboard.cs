using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    private const float _rotationSpeed = 5f;

    public void Init(Camera mainCamera)
    {
        _mainCamera = mainCamera;
    }

    public void RotateToCameraNow()
    {
        transform.rotation = GetRotation();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, GetRotation(), _rotationSpeed * Time.deltaTime);
    }

    private Quaternion GetRotation()
    {
        Quaternion rotation = Quaternion.LookRotation(_mainCamera.transform.position - transform.position, _mainCamera.transform.up);
        return Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, 0);
    }
}