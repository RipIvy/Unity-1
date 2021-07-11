using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _bulletPrefab;

    private bool _triggered;

    private void FixedUpdate()
    {
        if (_triggered)
        {
            transform.LookAt(_target);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _triggered = true;
            //GameObject bullet = Instantiate(_bulletPrefab, gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _triggered = false;
        }
    }
}
