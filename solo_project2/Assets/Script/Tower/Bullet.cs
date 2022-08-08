using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public TOWER TOWER;
    [HideInInspector] public Vector3 TowerPosition;
    [HideInInspector] public Vector3 TargetPosition;
    
    [HideInInspector] public float AttackPower;
    [HideInInspector] public float AttackDistance;

    [Header("ICE")]
    [HideInInspector] public float ICE_Slow;
    [HideInInspector] public float ICE_Time;

    [Header("POSION")]
    [HideInInspector] public float POSION_Time;

    [Header("DEATH")]
    [HideInInspector] public float DEATH_Percent;

    [HideInInspector] public float BulletSpeed;

    private float MyDistance;


    private void Start()
    {
        Destroy(gameObject, 3.0f);
    }
    void Update()
    {
        transform.Translate(new Vector3(0, 0.07f, 1) * Time.deltaTime * BulletSpeed);
        MyDistance = Vector3.Distance(transform.position, TowerPosition);
        if (MyDistance > AttackDistance + 3f)
        {
            //사거리 넘기면 삭제
            Destroy(gameObject);
        }
    }
    
}
