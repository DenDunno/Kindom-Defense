using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class EventSystemExtensions
{
    public static bool IsPointerOverUIObject(this EventSystem eventSystem)
    {
        var eventDataCurrentPosition = new PointerEventData(eventSystem)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };
        
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}