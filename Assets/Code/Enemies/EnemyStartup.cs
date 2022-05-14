using System;
using BehaviorDesigner.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class EnemyStartup
{
    [SerializeField] private Canvas _healthBarCanvas;
    [SerializeField] private Billboard _billboard;
    [SerializeField] private BehaviorTree _behaviorTree;
    private const string _targetPositionName = "KingdomPosition";
    
    public void Init(Transform kingdom, Camera mainCamera)
    {
        _behaviorTree.SetVariableValue(_targetPositionName, kingdom.position);
        _healthBarCanvas.worldCamera = mainCamera;
        _billboard.Init(mainCamera);
    }
}