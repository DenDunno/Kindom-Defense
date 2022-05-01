using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveList", menuName = "ScriptableObjects/WaveList", order = 1)]
public class WaveList : ScriptableObject
{
    [SerializeField] private List<Wave> _waves;

    public Queue<Wave> Waves => new Queue<Wave>(_waves);
}