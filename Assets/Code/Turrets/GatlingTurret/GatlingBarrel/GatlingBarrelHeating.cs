using UnityEngine;

public class GatlingBarrelHeating : IUpdatable
{
    private readonly MeshRenderer _barrelRenderer;
    private readonly GatlingBarrelSpeed _gatlingBarrelSpeed;
    private readonly Color _targetHeatColor = new Color(0.27f, 0f, 0f);
    private readonly MaterialPropertyBlock _materialPropertyBlock;
    private readonly int _emissionColorId;

    public GatlingBarrelHeating(MeshRenderer barrelRenderer, GatlingBarrelSpeed gatlingBarrelSpeed)
    {
        _barrelRenderer = barrelRenderer;
        _gatlingBarrelSpeed = gatlingBarrelSpeed;
        _materialPropertyBlock = new MaterialPropertyBlock();
        _emissionColorId = Shader.PropertyToID("_EmissionColor");
        _barrelRenderer.material.EnableKeyword("_EMISSION");
    }

    void IUpdatable.Update()
    {
        if (_gatlingBarrelSpeed.IsAccelerating)
        {
            HeatUpBarrel();
        }
    }
    
    private void HeatUpBarrel()
    {
        Color color = Color.Lerp(Color.black, _targetHeatColor, _gatlingBarrelSpeed.SpeedRatio);
        _materialPropertyBlock.SetColor(_emissionColorId, color);
        _barrelRenderer.SetPropertyBlock(_materialPropertyBlock);
    }
}