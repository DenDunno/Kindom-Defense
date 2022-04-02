using System;
using System.Collections;
using UnityEngine;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

[Serializable]
public class DissolveAnimation : Action
{
    [SerializeField] private Renderer[] _renderers;
    private MaterialPropertyBlock _dissolvePropertyBlock;
    private const string _dissolveName = "_DissolveFactor";
    private const float _dissolveSpeed = 0.25f;
    private const float _timeBeforeDissolving = 2f;
    private int _dissolveId;

    public override void OnStart()
    {
        _dissolveId = Shader.PropertyToID(_dissolveName);
        _dissolvePropertyBlock = new MaterialPropertyBlock();

        StartCoroutine(Dissolve());
    }

    private IEnumerator Dissolve()
    {
        yield return new WaitForSeconds(_timeBeforeDissolving);
        
        for (float dissolve = 0; dissolve < 1; dissolve += Time.deltaTime * _dissolveSpeed)
        {
            _dissolvePropertyBlock.SetFloat(_dissolveId, dissolve);
        
            _renderers.ForEach(renderer => renderer.SetPropertyBlock(_dissolvePropertyBlock));

            yield return null;
        }
    }
}