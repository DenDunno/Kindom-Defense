using UnityEngine;

public class ColliderDelete : MonoBehaviour
{
    [ContextMenu("Delete")]
    public void Delete()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        
        for(int i = 0 ; i < colliders.Length; ++i)
            DestroyImmediate(colliders[i]);
    }
}