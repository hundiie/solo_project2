using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWORD : MonoBehaviour
{
    private MonsterState _MonsterState;
    public bool attackMotioning;
    public float attackPower;

    private void Start()
    {
        attackPower = 10;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster" && attackMotioning)
        {
            _MonsterState = other.GetComponent<MonsterState>();
            _MonsterState.MonsterHP -= attackPower;
        }
    }
}
