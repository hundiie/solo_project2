using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ObjectType
{
    Player,
    Monster,
}
public class CharacterStatus : MonoBehaviour
{
    // 몬스터 관련
    private MonsterState _MonsterState;
    public ObjectType CharacterType;

    [Header("HP")]
    public float MaxHP;
    [HideInInspector] public float HP;
    [HideInInspector] public float HPpercent;

    [Header("Speed")]
    public float Speed;

    [Header("Attack")]
    public float AttackPower;
    public float AttackSpeed;

    [Header("Debuff")]
    public bool Hit;
    public bool Slow;
    public bool Posion;
    public bool paralysis;

    private void Start()
    {
        switch (CharacterType)
        {
            case ObjectType.Player:
                {
                    GetComponent<PlayerManager>().attackSpeed = AttackSpeed;
                    GetComponent<PlayerManager>().attackPower = AttackPower;
                    GetComponent<PlayerManager>().PlayerSpeed = Speed;
                }
                break;
            case ObjectType.Monster:
                {
                    GetComponent<NavMeshAgent>().speed = Speed;
                    _MonsterState = GetComponent<MonsterState>();
                }
                break;
            default:
                break;
        }

        HP = MaxHP;
        HPpercent = (HP * MaxHP) / 100.0f;

        Hit = false;
        Slow = false;
        Posion = false;
    }

    private void Update()
    {
        //오브젝트 몬스터

        switch (CharacterType)
        {
            case ObjectType.Player:
                {

                }
                break;
            case ObjectType.Monster:
                {
                    if (HP <= 0)
                    {
                        _MonsterState.Die = true;
                    }
                }
                break;
            default:
                break;
        }

    }
    float RedTime = 0;
    public void StatusHit(float Hit_Damage)
    {
        HP -= Hit_Damage;
        HPpercent = (HP * MaxHP) / 100.0f;

        //MAT.color = Color.red;
        Hit = false;
    }

    private float SaveSlowValue = 0;
    public void StatusSlow(float Slow_value, float Slow_Time)
    {
        float SlowDelay = 0f;
        if (SaveSlowValue < Slow_value)
        {
            SaveSlowValue = Slow_value;
        }

        switch (CharacterType)
        {
            case ObjectType.Player:
                {
                    GetComponent<PlayerManager>().PlayerSpeed = (Speed / 100) * SaveSlowValue;

                    while (SlowDelay <= Slow_Time)
                    {
                        SlowDelay += Time.deltaTime;
                    }
                    GetComponent<PlayerManager>().PlayerSpeed = Speed;
                }
                break;
            case ObjectType.Monster:
                {
                    GetComponent<NavMeshAgent>().speed = (Speed / 100) * SaveSlowValue;

                    while (SlowDelay <= Slow_Time)
                    {
                        SlowDelay += Time.deltaTime;
                    }
                    GetComponent<NavMeshAgent>().speed = Speed;
                }
                break;
            default:
                break;
        }
        SaveSlowValue = 0;

        Slow = false;
    }
    float SavePosionDamage = 0;
    public void StatusPosion(float Posion_Damage, float Posion_Time)
    {
        float PosionDelay = 0f;

        if (SavePosionDamage < Posion_Damage)
        {
            SavePosionDamage = Posion_Damage;
        }

        float SecDamage = SavePosionDamage / 60 * Time.deltaTime;

        while (PosionDelay <= Posion_Time)
        {
            PosionDelay += Time.deltaTime;
            HP -= SecDamage;

            if (HP <= 0)
            {
                break;
            }
        }

        SavePosionDamage = 0;
        Posion = false;
    }
}