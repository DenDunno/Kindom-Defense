using System;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

[Serializable]
public class PlayDissolveAnimation : Action
{
    [SerializeField] private Renderer[] _renderers;
    private const float _dissolveSpeed = 0.35f;
    private float _dissolveAmount = 0;
    private EnemyDissolve _enemyDissolve;

    public override void OnStart()
    {
        _enemyDissolve = new EnemyDissolve(_renderers);
        _dissolveAmount = 0;
    }

    public override TaskStatus OnUpdate()
    {
        _dissolveAmount += Time.deltaTime * _dissolveSpeed;
        _enemyDissolve.SetDissolve(_dissolveAmount);

        return _dissolveAmount >= 1 ? TaskStatus.Success : TaskStatus.Running;
    }
}