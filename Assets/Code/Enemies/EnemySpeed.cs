using UnityEngine;
using UnityEngine.AI;

public class EnemySpeed : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    private float _startSpeed;

    private void Start()
    {
        _startSpeed = _agent.speed;
    }

    public void SlowDown()
    {
        SetSpeed(_startSpeed / 2, 0.5f);
    }
    
    public void ReturnStartSpeed()
    {
        SetSpeed(_startSpeed, 1);
    }

    private void SetSpeed(float agentSpeed, float animatorSpeed)
    {
        _agent.speed = agentSpeed;
        _animator.speed = animatorSpeed;
    }
}