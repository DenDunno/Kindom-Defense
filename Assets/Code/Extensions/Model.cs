using System;
using UnityEngine;

[Serializable]
public class Model
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Material _material;

    public Mesh Mesh => _mesh;
    public Material Material => _material;
}