using UnityEngine;

public class EnemyDissolve
{
    private readonly Renderer[] _renderers;
    private MaterialPropertyBlock _materialPropertyBlock = new MaterialPropertyBlock();
    private int _dissolveId;
    
    public EnemyDissolve(Renderer[] renderers)
    {
        _renderers = renderers;
        _dissolveId = Shader.PropertyToID("_DissolveFactor");
    }

    public void SetDissolve(float dissolve)
    {
        _materialPropertyBlock.SetFloat(_dissolveId, dissolve);
        _renderers.ForEach(renderer => renderer.SetPropertyBlock(_materialPropertyBlock));
    }
}