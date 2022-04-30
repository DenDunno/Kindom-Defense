using BehaviorDesigner.Runtime;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BehaviorTree _behaviorTree;
    private const string _targetPositionName = "KingdomPosition";
    
    public void Init(Vector3 targetPosition)
    {
        _behaviorTree.SetVariableValue(_targetPositionName, targetPosition);
    }
}