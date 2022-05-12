using UnityEngine;

public class SkillCast : MonoBehaviour
{
    [SerializeField] private TimeField _timeField;
    [SerializeField] private Camera _mainCamera;
    
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit info))
            {
                if (info.collider is TerrainCollider)
                {
                    _timeField.Cast(info.point);
                }
            }
        }
    }
}