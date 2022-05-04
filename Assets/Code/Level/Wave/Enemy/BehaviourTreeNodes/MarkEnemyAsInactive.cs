using System;
using UnityEngine;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

[Serializable]
public class MarkEnemyAsInactive : Action
{
    [SerializeField] private Enemy _enemy;
    
    public override void OnStart()
    {
        _enemy.MarkAsInactive();
        gameObject.SetActive(false);
    }
}