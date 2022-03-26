using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public abstract class TakeDamage : Conditional
{
    private bool _damageTaken = false;

    public override TaskStatus OnUpdate()
    {
        return _damageTaken ? TaskStatus.Success : TaskStatus.Failure;
    }

    public override void OnEnd()
    {
        _damageTaken = false;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (CheckIfDamageTaken(other)) 
        {
            
            _damageTaken = true;
        }
    }

    protected abstract bool CheckIfDamageTaken(Collider other);
}