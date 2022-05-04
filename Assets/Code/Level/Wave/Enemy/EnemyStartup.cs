using BehaviorDesigner.Runtime;
using UnityEngine;

public class EnemyStartup : MonoBehaviour
{
    [SerializeField] private BehaviorTree _behaviorTree;
    [SerializeField] private Canvas _healthBarCanvas;
    [SerializeField] private Billboard _billboard;
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private EnemyHealth _enemyHealth;
    private const string _targetPositionName = "KingdomPosition";
    private const string _dissolveName = "_DissolveFactor";
    private bool _isInited;
    
    public void Init(Transform kingdom, Camera mainCamera)
    {
        if (_isInited)
        {
            Reset();
        }
        else
        {
            Initialize(kingdom, mainCamera);
        }
    }

    private void Initialize(Transform kingdom, Camera mainCamera)
    {
        _isInited = true;
        _behaviorTree.SetVariableValue(_targetPositionName, kingdom.position);
        _healthBarCanvas.worldCamera = mainCamera;
        _billboard.Init(mainCamera);
    }

    private void Reset()
    {
        _behaviorTree.OnBehaviorRestarted();
        _enemyHealth.ResetHealth();
        _renderers.ForEach(enemyRenderer => enemyRenderer.material.SetFloat(_dissolveName, 0));
    }
}