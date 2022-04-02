using UnityEngine;

public abstract class Damage : MonoBehaviour
{
    [SerializeField] private float _value;

    public float Value => _value;
}