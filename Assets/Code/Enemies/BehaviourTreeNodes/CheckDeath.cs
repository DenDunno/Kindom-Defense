using System;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

[Serializable]
public class CheckDeath : Conditional
{
    [SerializeField] private Health _health;

    public override TaskStatus OnUpdate()
    {
        return _health.IsDead ? TaskStatus.Success : TaskStatus.Failure;
    }
}