using UnityEngine;

public abstract class PoolableObject : MonoBehaviour, IPoolableObject
{
    private bool _isActive = true;

    bool IPoolableObject.IsActive => _isActive;
    
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
        _isActive = active;
        gameObject.SetActive(active);
    }
    
    protected virtual void OnReset() {}
}