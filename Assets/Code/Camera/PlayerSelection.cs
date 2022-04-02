using UnityEngine;

public class PlayerSelection : IUpdatable
{
    private readonly Camera _mainCamera;
    private readonly RaycastHit[] _results = new RaycastHit[5];
    private ISelectable _selectable;
    
    public PlayerSelection(Camera mainCamera)
    {
        _mainCamera = mainCamera;
    }
    
    void IUpdatable.Update()
    {
        if (Input.touchCount > 0)
        {
            int size = Physics.RaycastNonAlloc(_mainCamera.ScreenPointToRay(Input.mousePosition), _results);
            _selectable.Unselect();

            for (var i = 0; i < size; ++i)
            {
                if (_results[i].collider.TryGetComponent(out _selectable))
                {
                    _selectable.Select();
                }
            }
        }
    }
}