using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterState : MonoBehaviour
{
    private NavMeshAgent agent;

    public bool Die;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        Die = false;
    }

    void Update()
    {
        if (Die)
        {
            MonsterDie();
        }
    }

    public void MonsterDie()
    {
        agent.speed = 0;

        Destroy(gameObject,1f);
    }
}
