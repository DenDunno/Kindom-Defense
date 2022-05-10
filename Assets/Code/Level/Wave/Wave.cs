using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    [SerializeField] private List<EnemiesGroup> _enemiesGroups;

    public List<EnemiesGroup> EnemiesGroups => _enemiesGroups;
}