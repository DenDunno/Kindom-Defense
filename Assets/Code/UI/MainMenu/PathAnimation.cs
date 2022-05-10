using System;
using UnityEngine;

public class PathAnimation : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    private int _currentIndex;
    private const float _speed = 2f;
    private const float _epsilon = 0.01f;

    public event Action Finished; 

    private void Update()
    {
        if (Vector3.Distance(transform.position, _wayPoints[_currentIndex].position) < _epsilon)
        {
            _currentIndex++;
            
            if (_currentIndex == _wayPoints.Length)
            {
                enabled = false;
                Finished?.Invoke();
                return;
            }
        }
        
        transform.position = Vector3.Lerp(transform.position, _wayPoints[_currentIndex].position, _speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _wayPoints[_currentIndex].rotation, _speed * Time.deltaTime);
    }
}