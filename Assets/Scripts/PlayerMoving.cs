using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _turnSpeed = 1f;
    
    Vector3 _direction;
    private float _rotation = 0f;

    void Update()
    {
        _direction.z = Input.GetAxis("Vertical");
        _rotation = Input.GetAxis("Horizontal") * _turnSpeed;
    }

    private void FixedUpdate()
    {
        var speed = _direction.normalized * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);
        transform.Rotate(0f, _rotation, 0f);
    }
}
