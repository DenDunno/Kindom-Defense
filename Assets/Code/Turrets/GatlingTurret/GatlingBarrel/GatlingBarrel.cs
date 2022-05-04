using UnityEngine;

public class GatlingBarrel : MonoBehaviour
{
    [SerializeField] private TowerRadar _towerRadar;
    [SerializeField] private MeshRenderer _meshRenderer;
    private GatlingBarrelSpeed _gatlingBarrelSpeed;
    private Dependencies _dependencies;
    
    public bool ReadyForShooting => _gatlingBarrelSpeed.SpeedRatio >= 1;

    private void Start()
    {
        _dependencies = new Dependencies(new object[]
        {
            _gatlingBarrelSpeed = new GatlingBarrelSpeed(_towerRadar),
            new GatlingBarrelHeating(_meshRenderer, _gatlingBarrelSpeed),
            new GatlingBarrelSpinning(transform, _gatlingBarrelSpeed)
        });
    }

    private void Update()
    {
        _dependencies.UpdateForEach();
    }
}