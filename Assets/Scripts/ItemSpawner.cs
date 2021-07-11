using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spoint;

    private GameObject[] item;

    void Start()
    {
        for(int i = 0; i < _spoint.Length; i++)
        {
            Instantiate(_prefab, _spoint[i].position, _spoint[i].rotation);
        }
    }
}
