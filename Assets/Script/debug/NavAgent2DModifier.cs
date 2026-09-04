using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent2DModifier : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private EnemyCore _enemyCore;
    void Awake()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = _enemyCore.getSpeed();
    }
}
