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

    public float BulletSpeed;

    private float MyDistance;


    private void Start()
    {
        Destroy(gameObject, 3.0f);
    }
    void Update()
    {
        transform.Translate((TargetPosition - new Vector3(0, 0.15f, 0)) * Time.deltaTime * BulletSpeed);

        MyDistance = Vector3.Distance(transform.position, TowerPosition);
        if (MyDistance > AttackDistance + 0.5f)
        {
            //��Ÿ� �ѱ�� ����
            Destroy(gameObject);
        }
    }
    
}
