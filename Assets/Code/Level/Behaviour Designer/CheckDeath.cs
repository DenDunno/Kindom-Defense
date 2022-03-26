using System;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

[Serializable]
public class CheckDeath : Conditional
{
    [SerializeField] private SharedHealth _health;

    public override TaskStatus OnUpdate()
    {
        return _health.Value.IsDead ? TaskStatus.Success : TaskStatus.Failure;
    }
}