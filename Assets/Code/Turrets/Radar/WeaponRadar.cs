using UnityEngine;

public class WeaponRadar : MonoBehaviour
{
    [SerializeField] private WeaponSettings _weaponSettings;
    [SerializeField] private float _enemyOffset;
    private EnemyRadar _enemyRadar;
    private Health _target;

    public bool HasTarget => _target != null;
    public Transform Target => _target.transform;
    public Vector3 TargetPosition => Target.position + Target.forward * _enemyOffset;

    private void Start()
    {
        _enemyRadar = new EnemyRadar(10, transform, _weaponSettings.DetectionRadius);
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
        return Vector3.Distance(_target.transform.position, transform.position) > _weaponSettings.DetectionRadius;
    }
}