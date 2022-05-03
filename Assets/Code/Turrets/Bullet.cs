using UnityEngine;

public class Bullet : MonoBehaviour, IPoolableObject
{
    private Transform _target;
    private const float _speed = 15f;
    
    public bool IsActive { get; private set; }
    
    public void Init(Transform target)
    {
        _target = target;
        IsActive = true;
        Update();
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.LookAt(_target);
    }

    private void OnTriggerEnter(Collider enemy)
    {
        gameObject.SetActive(false);
        IsActive = false;
    }
}