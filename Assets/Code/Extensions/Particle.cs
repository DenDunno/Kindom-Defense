using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Particle : PoolableObject
{
    [SerializeField] private ParticleSystem _particle;

    public async void Play()
    {
        _particle.Play();
        await UniTask.Delay(TimeSpan.FromSeconds(_particle.main.duration));
        MarkAsInactive();
    }
}