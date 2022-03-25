using UnityEngine;

public class CameraPanning : IUpdatable
{
    private readonly Camera _mainCamera;
    private Vector3 _touchAnchor;
    private Vector3 _worldAnchor;

    public CameraPanning(Camera mainCamera)
    {
        _mainCamera = mainCamera;
    }

    void IUpdatable.Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _touchAnchor = Input.mousePosition;
            _worldAnchor = _mainCamera.transform.position;
        }
        
        if(Input.GetMouseButton(0))
        {
            _mainCamera.transform.position = EvaluateCameraPosition();        
        }
    }

    private Vector3 EvaluateCameraPosition()
    {
        Vector3 touchPosition = Input.mousePosition;
        touchPosition.z = _touchAnchor.z = _worldAnchor.y;
        
        Vector3 direction = _mainCamera.ScreenToWorldPoint(touchPosition) - _mainCamera.ScreenToWorldPoint(_touchAnchor);
        Vector3 position = _worldAnchor - direction;

        return new Vector3(position.x, _mainCamera.transform.position.y, position.z);
    }
}