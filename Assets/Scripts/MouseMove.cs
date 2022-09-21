using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class MouseMove : MonoBehaviour
{
    private Vector3 _mousePressDownPos;
    private Vector3 _mouseReleasePos;
    private float _forceMultiplier = 3;
    private Rigidbody _rb;
    
    private bool _isShoot;

     

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        _mousePressDownPos = Input.mousePosition;
        
    }

    private void OnMouseUp()
    {
       _mouseReleasePos = Input.mousePosition;
        
        Shoot(force: _mousePressDownPos - _mouseReleasePos);
    }

    private void Shoot(Vector3 force)
    {
        if (_isShoot)
            return;

        _rb.AddForce(new Vector3(force.x, force.y * 0, force.y) * _forceMultiplier);
    }

    
}
