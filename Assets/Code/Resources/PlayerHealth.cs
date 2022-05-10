using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerStatsUI _healthUI;
    [SerializeField] private Health _kingdomHealth;

    private void OnEnable()
    {
        _kingdomHealth.DamageTaken += SetPlayerHealth;
    }
    
    private void OnDisable()
    {
        _kingdomHealth.DamageTaken -= SetPlayerHealth;
    }

    private void SetPlayerHealth(float current, float max)
    {
        _healthUI.SetValue((int)current);
    }
}