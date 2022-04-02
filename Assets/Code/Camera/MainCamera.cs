using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private CameraBorders _cameraBorders;
    [SerializeField] private Camera _mainCamera;
    private Dependencies _dependencies;
    
    private void Awake()
    {
        _dependencies = new Dependencies(new object[]
        {
            new CameraZoom(),
            new CameraPanning(_mainCamera),
            new PlayerSelection(_mainCamera)
        });
    }

    private void OnEnable()
    {
        _dependencies.SubscribeForEach();
    }
    
    private void OnDisable()
    {
        _dependencies.UnsubscribeForEach();
    }

    private void Update()
    {
        _dependencies.UpdateForEach();
    }
}