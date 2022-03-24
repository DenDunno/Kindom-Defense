using UnityEngine;

public class CameraPanning : IUpdatable
{
    private readonly Camera _mainCamera;
    private Vector3 _anchorPosition;
    private Vector3 _cameraPosition;

    public CameraPanning(Camera mainCamera)
    {
        _mainCamera = mainCamera;
    }

    void IUpdatable.Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _anchorPosition = Input.mousePosition;
            _cameraPosition = _mainCamera.transform.position;
        }
        
        if(Input.GetMouseButton(0))
        {
            _mainCamera.transform.position = EvaluateCameraPosition();        
        }
    }

    private Vector3 EvaluateCameraPosition()
    {
        Vector3 currentPosition = Input.mousePosition;
        currentPosition.z = _anchorPosition.z = _cameraPosition.y;
        
        Vector3 direction = _mainCamera.ScreenToWorldPoint(currentPosition) - _mainCamera.ScreenToWorldPoint(_anchorPosition);
        Vector3 position = _cameraPosition - direction;

        return new Vector3(position.x, _mainCamera.transform.position.y, position.z);
    }
}