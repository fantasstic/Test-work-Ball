using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class SwipeMove : MonoBehaviour
{
    [SerializeField] private float _throwForceX = 1f;
    [SerializeField] private float _throwForceZ = 50f;

    private Vector3 _startPosition, _endPosition, _direction;
    private float _touchTimeStart, _touchTimeFinish, _timeInterval;
    private Rigidbody _rigidbody;

    
    Vector3 _currentFingerPos;
    Vector3 _targetPosition;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _touchTimeStart = Time.time;
            _startPosition = Input.GetTouch(0).position;
            
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _touchTimeFinish = Time.time;
            _timeInterval = _touchTimeFinish - _touchTimeStart;
            _endPosition = Input.GetTouch(0).position;
            _direction = _startPosition - _endPosition;

            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(-_direction.x * _throwForceX, _direction.y * 0, _direction.y * _throwForceZ);
            
        }
    }

    
}
