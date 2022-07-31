using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWORD : MonoBehaviour
{
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
            other.GetComponent<CharacterStatus>().StatusHit(attackPower);
        }
    }
}
