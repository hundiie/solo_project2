using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterState : MonoBehaviour
{
    private NavMeshAgent agent;
    private CharacterStatus status;
    public bool Die;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<CharacterStatus>();
        StartCoroutine(status.StatusStun(5));
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
        Destroy(gameObject);
    }


}
