using UnityEngine;

public class PoolableObject : MonoBehaviour, IPoolableObject
{
    public bool IsActive { get; private set; } = true;
    
    void IPoolableObject.ResetObject()
    {
        ToggleObject(true);
        OnReset();
    }

    public void MarkAsInactive()
    {
        ToggleObject(false);
    }

    private void ToggleObject(bool active)
    {
        IsActive = active;
        gameObject.SetActive(active);
    }
    
    protected virtual void OnReset() {}
}