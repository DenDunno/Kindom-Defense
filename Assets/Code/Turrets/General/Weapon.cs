using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private TowerRadar _towerRadar;

    private void Update()
    {
        if (_towerRadar.HasTarget)
        {
            UpdateWeapon(_towerRadar.TargetEnemy.transform);
        }
    }

    protected abstract void UpdateWeapon(Transform targetEnemy);
}