using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Particle : MonoBehaviour, IPoolableObject
{
    [SerializeField] private ParticleSystem _particle;

    public bool IsActive => _particle.isPlaying;

    public void Play()
    {
        _particle.Play();
    }

    public void ResetObject() {}
}