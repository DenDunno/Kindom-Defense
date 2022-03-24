using UnityEngine;

public class CameraClamping
{
    private readonly CameraBorders _cameraBorders;

    public CameraClamping(CameraBorders cameraBorders)
    {
        _cameraBorders = cameraBorders;
    }

    public Vector3 Clamp(Vector3 targetPosition)
    {
        targetPosition.x = Mathf.Clamp(targetPosition.x, _cameraBorders.DownBorder, _cameraBorders.TopBorder);
        targetPosition.z = Mathf.Clamp(targetPosition.z, _cameraBorders.LeftBorder, _cameraBorders.RightBorder);

        return targetPosition;
    }
}