using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform pointSpawn;

    private bool _triggered = false;
    private bool _ready = true;

    private void FixedUpdate()
    {
        if (_triggered)
        {
            transform.LookAt(_target);

            if (_ready)
            {
                Instantiate(_bulletPrefab, pointSpawn.position, transform.rotation);
                _ready = false;
                StartCoroutine(TimeShoot());
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    IEnumerator TimeShoot()
    {
        yield return new WaitForSeconds(1.5f);
        _ready = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _triggered = true;
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
