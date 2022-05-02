using UnityEngine;

public class GatlingTurret : MonoBehaviour
{
    [SerializeField] private TowerRadar _towerRadar;

    private void OnDrawGizmos()
    {
        if (_towerRadar.ClosestEnemy != null)
            Gizmos.DrawLine(transform.position, _towerRadar.ClosestEnemy.transform.position);
    }
}
