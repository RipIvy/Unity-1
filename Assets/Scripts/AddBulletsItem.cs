using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBulletsItem : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 2f;

    void FixedUpdate()
    {
        transform.Rotate(0f, _rotationSpeed, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
