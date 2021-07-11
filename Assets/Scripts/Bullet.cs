using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    bool dead = false;

    private void Start()
    {
        StartCoroutine(LiveTime());
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed * Time.fixedDeltaTime);

        if (dead)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator LiveTime()
    {
        yield return new WaitForSeconds(5f);
        dead = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
