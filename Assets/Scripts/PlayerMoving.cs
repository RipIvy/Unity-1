using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed ;
    
    Vector3 _direction;
    private float _rotation;

    private void Update()
    {
        _direction.z = Input.GetAxis("Vertical");
        _direction.x = Input.GetAxis("Horizontal");
        _rotation = Input.GetAxis("Mouse X");
    }

    private void FixedUpdate()
    {
        transform.Translate(_direction.normalized * _speed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.up * _rotation * _turnSpeed * Time.fixedDeltaTime);
    }
}
