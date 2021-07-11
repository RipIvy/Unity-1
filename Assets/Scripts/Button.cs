using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject door;

    private bool isOpened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isOpened)
        {
            door.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }
}
