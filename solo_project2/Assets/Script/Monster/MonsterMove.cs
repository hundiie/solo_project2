using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MonsterMove : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] private GameObject target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.transform.position);
    }
}
