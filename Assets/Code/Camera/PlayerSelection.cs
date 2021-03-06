using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSelection : IUpdatable
{
    private readonly Camera _mainCamera;
    private readonly RaycastHit[] _results = new RaycastHit[5];
    private TowerSelection _tower;

    public PlayerSelection(Camera mainCamera)
    {
        _mainCamera = mainCamera;
    }
    
    void IUpdatable.Update()
    {
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            int size = Physics.RaycastNonAlloc(_mainCamera.ScreenPointToRay(Input.mousePosition), _results);

            for (int i = 0; i < size; ++i)
            {
                if (_results[i].collider.TryGetComponent(out TowerSelection selectable))
                {
                    if (selectable.IsSelected == false)
                    {
                        _tower?.Unselect();
                        _tower = selectable;
                        _tower.Select();
                    }
                }
            }
        }
    }
}