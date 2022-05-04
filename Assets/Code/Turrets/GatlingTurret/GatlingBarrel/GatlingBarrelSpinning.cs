using UnityEngine;

public class GatlingBarrelSpinning : IUpdatable
{
    private readonly Transform _transform;
    private readonly GatlingBarrelSpeed _gatlingBarrelSpeed;

    public GatlingBarrelSpinning(Transform transform, GatlingBarrelSpeed gatlingBarrelSpeed)
    {
        _transform = transform;
        _gatlingBarrelSpeed = gatlingBarrelSpeed;
    }

    void IUpdatable.Update()
    {
        SpinBarrel();
    }

    private void SpinBarrel()
    {
        _transform.rotation *= Quaternion.Euler(0, 0, _gatlingBarrelSpeed.Value * Time.deltaTime);
    }
}