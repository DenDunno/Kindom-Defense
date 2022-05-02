using UnityEngine;

public class PlayerSelection : IUpdatable
{
    private readonly Camera _mainCamera;
    private readonly RaycastHit[] _results = new RaycastHit[5];
    private TowerBaseSelection _selectable;

    public PlayerSelection(Camera mainCamera)
    {
        _mainCamera = mainCamera;
    }
    
    void IUpdatable.Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            int size = Physics.RaycastNonAlloc(_mainCamera.ScreenPointToRay(Input.mousePosition), _results);

            for (int i = 0; i < size; ++i)
            {
                if (_results[i].collider.TryGetComponent(out TowerBaseSelection selectable))
                {
                    if (selectable.IsSelected == false)
                    {
                        _selectable?.Unselect();
                        _selectable = selectable;
                        _selectable.Select();
                    }
                }
            }
        }
    }
}