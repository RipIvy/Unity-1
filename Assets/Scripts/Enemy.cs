using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    Vector3 _direction;

    void Start()
    {
        _direction.z = 1;
    }

    private void FixedUpdate()
    {
        if (gameObject.tag == "Enemy")
        {
            var speed = _direction.normalized * _speed * Time.fixedDeltaTime;
            transform.Translate(speed);
        }
    }
}
