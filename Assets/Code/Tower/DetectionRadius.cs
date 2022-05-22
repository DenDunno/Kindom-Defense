using UnityEngine;

public class DetectionRadius : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    
    private void OnEnable()
    {
        float detectionRadius = _tower.Weapon.Settings.DetectionRadius;
        transform.localScale = Vector3.one * (detectionRadius * 2);
    }
}