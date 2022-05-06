using UnityEngine;

public class PlayerSelection : IUpdatable
{
    private readonly Camera _mainCamera;
    private readonly RaycastHit[] _results = new RaycastHit[5];
    private Tower _tower;

    public PlayerSelection(Camera mainCamera)
    {
        _mainCamera = mainCamera;
    }
    
    void IUpdatable.Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int size = Physics.RaycastNonAlloc(_mainCamera.ScreenPointToRay(Input.mousePosition), _results);

            for (int i = 0; i < size; ++i)
            {
                if (_results[i].collider.TryGetComponent(out Tower selectable))
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