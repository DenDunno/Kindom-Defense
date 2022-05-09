using UnityEngine;

public class DetectionRadius : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    
    private void OnEnable()
    {
        transform.localScale = Vector3.one * (_tower.Weapon.Radar.DetectionRadius * 2);
    }
}