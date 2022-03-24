using System;
using UnityEngine;

[Serializable]
public class CameraBorders
{
    [field: SerializeField] public float TopBorder { get; private set; }
    [field: SerializeField] public float DownBorder { get; private set; }
    [field: SerializeField] public float LeftBorder { get; private set; }
    [field: SerializeField] public float RightBorder { get; private set; }
}