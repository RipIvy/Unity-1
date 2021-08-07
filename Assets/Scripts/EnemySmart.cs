using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySmart : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform[] points;

    private int currentPoint = 0;

    private void Start()
    {
        _agent.SetDestination(points[currentPoint].position);
    }

    private void Update()
    {
        if (_agent.remainingDistance < _agent.stoppingDistance)
        {
            currentPoint = (currentPoint + 1) % points.Length;
            _agent.SetDestination(points[currentPoint].position);
        }
    }
}
