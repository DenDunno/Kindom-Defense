using System;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

[Serializable]
public class CheckDestination : Conditional
{
    [SerializeField] private SharedVector3 _destination;
    private float _destinationRadius = 0.5f;
    
    public override TaskStatus OnUpdate()
    {
        if (Vector3.Distance(_destination.Value, transform.position) < _destinationRadius)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}