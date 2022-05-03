using System;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

[Serializable]
public class CheckDeath : Conditional
{
    [SerializeField] private EnemyHealth _enemyHealth;

    public override TaskStatus OnUpdate()
    {
        return _enemyHealth.IsDead ? TaskStatus.Success : TaskStatus.Failure;
    }
}