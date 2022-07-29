using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterState : MonoBehaviour
{
    private Animator ANI;
    private Rigidbody RB;
    private NavMeshAgent agent;
    private MonsterMove _MonsterMove;

    [SerializeField]
    private float JUMP;
    private bool dieCheck;


    public float MonsterHP;
    public float MonsterSpeed;

    void Start()
    {
        ANI = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        _MonsterMove = GetComponent<MonsterMove>();

        agent.speed = MonsterSpeed;
        dieCheck = false;
    }

    void Update()
    {
        if (MonsterHP <= 0f)
        {
            MonsterDie();
        }
    }

    void MonsterDie()
    {
        ANI.SetTrigger("jump");
        agent.enabled = false;
        _MonsterMove.enabled = false;
        if (!dieCheck)
        {
            RB.AddForce(0, JUMP, 0);
            dieCheck = true;
        }
        
        Destroy(gameObject,1f);
    }
}
