using UnityEngine;

public class WeaponRadar : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 5;
    private const int _enemyLayerMask = 1 << 8;
    private readonly Collider[] _colliders = new Collider[5];
    
    public Health Target { get; private set; }
    public bool HasTarget => Target != null;
    public float DetectionRadius => _detectionRadius;
    
    private void Update()
    {
        if (NoTarget())
        {
            FindEnemy();
        }
    }

    private void FindEnemy()
    {
        int size = Physics.OverlapSphereNonAlloc(transform.position, _detectionRadius, _colliders, _enemyLayerMask);
        Target = null;
        
        for (var i = 0; i < size; ++i)
        {
            var enemy = _colliders[i].GetComponent<Health>();
            
            if (enemy.IsDead == false)
            {
                Target = enemy;
            }
        }
    }

    private bool NoTarget()
    {
        bool noTarget = true;

        if (Target != null)
        {
            noTarget = Target.IsDead || EnemyNotInRange();
        }

        return noTarget;
    }

    private bool EnemyNotInRange()
    {
        return Vector3.Distance(Target.transform.position, transform.position) > _detectionRadius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, _detectionRadius);
    }
}