using UnityEngine;

public class GatlingBarrel : MonoBehaviour
{
    [SerializeField] private WeaponRadar _weaponRadar;
    [SerializeField] private MeshRenderer _meshRenderer;
    private GatlingBarrelSpeed _gatlingBarrelSpeed;
    private IUpdatable[] _updatables;
    
    public bool ReadyForShooting => _gatlingBarrelSpeed.SpeedRatio >= 1;

    private void Start()
    {
        _updatables = new IUpdatable[]
        {
            _gatlingBarrelSpeed = new GatlingBarrelSpeed(_weaponRadar),
            new GatlingBarrelHeating(_meshRenderer, _gatlingBarrelSpeed),
            new GatlingBarrelSpinning(transform, _gatlingBarrelSpeed)
        };
    }

    private void Update()
    {
        foreach (IUpdatable updatable in _updatables)
        {
            updatable.Update();
        }
    }
}