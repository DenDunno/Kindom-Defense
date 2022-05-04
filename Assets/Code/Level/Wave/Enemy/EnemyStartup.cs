using System;
using BehaviorDesigner.Runtime;
using UnityEngine;

[Serializable]
public class EnemyStartup
{
    [SerializeField] private BehaviorTree _behaviorTree;
    [SerializeField] private Canvas _healthBarCanvas;
    [SerializeField] private Billboard _billboard;
    private const string _targetPositionName = "KingdomPosition";
    private bool _isInited;
    
    public void Init(Transform kingdom, Camera mainCamera)
    {
        if (_isInited)
            return;

        _isInited = true;
        _behaviorTree.SetVariableValue(_targetPositionName, kingdom.position);
        _healthBarCanvas.worldCamera = mainCamera;
        _billboard.Init(mainCamera);
    }
}