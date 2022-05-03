using BehaviorDesigner.Runtime;
using UnityEngine;

public class EnemyStartup : MonoBehaviour
{
    [SerializeField] private BehaviorTree _behaviorTree;
    [SerializeField] private Canvas _healthBarCanvas;
    [SerializeField] private Billboard _billboard;
    private const string _targetPositionName = "KingdomPosition";
    
    public void Init(Transform kingdom, Camera mainCamera)
    {
        _behaviorTree.SetVariableValue(_targetPositionName, kingdom.position);
        _healthBarCanvas.worldCamera = mainCamera;
        _billboard.Init(mainCamera);
    }
}