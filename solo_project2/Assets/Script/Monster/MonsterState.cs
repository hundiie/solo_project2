using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterState : MonoBehaviour
{
    private NavMeshAgent agent;
    private MonsterMove _MonsterMove;

    [Header("Monster HP")]
    public float MonsterMaxHP;
    public float MonsterHP;
    public float MonsterSpeed;
    public float HPpercent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _MonsterMove = GetComponent<MonsterMove>();

        agent.speed = MonsterSpeed;

        MonsterHP = MonsterMaxHP;
    }

    void Update()
    {
        if (MonsterHP <= 0f)
        {
            MonsterDie();
        }
        else
        {
            HPBAR();
        }
    }
    void HPBAR()
    {
        HPpercent = (MonsterHP * MonsterMaxHP) / 100.0f;
    }

    void MonsterDie()
    {
        agent.enabled = false;
        _MonsterMove.enabled = false;
        
        Destroy(gameObject,1f);
    }
}
