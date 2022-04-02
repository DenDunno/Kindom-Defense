using System;
using UnityEngine;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

[Serializable]
public class TurnOffParticles : Action
{
    [SerializeField] private ParticleSystem[] _particleSystems;

    public override void OnStart()
    {
        _particleSystems.ForEach(particleSystem => particleSystem.Stop());
    }
}