using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveList", menuName = "ScriptableObjects/WaveList", order = 1)]
public class WaveList : ScriptableObject
{
    [SerializeField] private List<Wave> _waves;

    public int Count => _waves.Count;
    public Wave this[int index] => _waves[index];
}