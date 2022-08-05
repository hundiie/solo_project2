using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private Tower _Tower;
    
    //구조체로 만들걸...

    [Header("오브젝트")]
    public GameObject[] Tower = new GameObject[0];
    public GameObject[] Bullet = new GameObject[0];
    public int[] MaxLevel;

    [Header("비용")]
    public int[] Money = new int[0];
    public int[] UpgradeMoney = new int[0];

    [Header("공격력")]
    public float[] AttackPower = new float[0];
    public float[] UpgradeAttackPower = new float[0];

    [Header("공격 속도")]
    public float[] AttackSpeed = new float[0];
    public float[] UpgradeAttackSpeed = new float[0];
    
    [Header("투사체 속도")]
    public float[] BulletSpeed = new float[0];
    public float[] UpgradeBulletSpeed = new float[0];

    [Header("사거리")]
    public float[] AttackDistance = new float[0];
    public float[] UpgradeAttackDistance = new float[0];
    

    [HideInInspector] public bool NOMAL;
    [HideInInspector] public bool ICE;
    [HideInInspector] public bool POSION;
    [HideInInspector] public bool DEATH;

    [Header("NONAL")]
    [Header("ICE")]
    public float ICE_Slow;
    public float Upgrade_ICE_Slow;
    public float ICE_Time;
    public float Upgrade_ICE_Time;

    [Header("POSION")]
    public float POSION_Time;
    public float Upgrade_POSION_Time;

    [Header("DEATH")]
    public float DEATH_Percent;
    public float Upgrade_DEATH_Percent;

    void Update()
    {

    }

    void TowerDataMaov()
    {

    }

}

