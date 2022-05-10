using UnityEngine;

public class WeaponRadar : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 5;
    private EnemyRadar _enemyRadar;
    private Health _target;

    public bool HasTarget => Target != null;
    public float DetectionRadius => _detectionRadius;
    public Transform Target => _target?.transform;
    
    private void Start()
    {
        _enemyRadar = new EnemyRadar(10, transform, _detectionRadius);
    }

    private void Update()
    {
        if (NoTarget())
        {
            _target = _enemyRadar.FindTarget();
        }
    }

    private bool NoTarget()
    {
        bool noTarget = true;

        if (_target != null)
        {
            noTarget = _target.IsDead || EnemyNotInRange();
        }

        return noTarget;
    }

    private bool EnemyNotInRange()
    {
        return Vector3.Distance(_target.transform.position, transform.position) > _detectionRadius;
    }
}