using UnityEngine;

public class TowerRadar : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 5;
    private const int _enemyLayerMask = 1 << 8;
    private readonly Collider[] _colliders = new Collider[5];
    
    public EnemyHealth TargetEnemy { get; private set; }
    public bool HasTarget => TargetEnemy != null;

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
        TargetEnemy = null;
        
        for (var i = 0; i < size; ++i)
        {
            var enemy = _colliders[i].GetComponent<EnemyHealth>();
            
            if (enemy.IsDead == false)
            {
                TargetEnemy = enemy;
            }
        }
    }

    private bool NoTarget()
    {
        bool noTarget = true;

        if (TargetEnemy != null)
        {
            noTarget = TargetEnemy.IsDead || EnemyNotInRange();
        }

        return noTarget;
    }

    private bool EnemyNotInRange()
    {
        return Vector3.Distance(TargetEnemy.transform.position, transform.position) > _detectionRadius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, _detectionRadius);
    }
}