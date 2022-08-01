using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum ObjectType
{
    Player,
    Monster,
}
public class CharacterStatus : MonoBehaviour
{
    // 몬스터 관련
    private MonsterState _MonsterState;
    [SerializeField] private GameObject SliderHpObject;
    private Slider SliderHP;
    public ObjectType CharacterType;


    //플레이어 관련
    private PlayerManager PL_Manager;
    [Header("HP")]
    public float MaxHP;
    //[HideInInspector] 
    public float HP;
    //[HideInInspector]
    public float HpPercent;

    

    [Header("Speed")]
    public float Speed;
    [HideInInspector] public float BasicSpeed;
    private NavMeshAgent Nav;

    [Header("Attack")]
    public float AttackPower;
    public float AttackSpeed;


    [Header("Debuff")]
    public bool Hit;
    public bool Slow;
    public bool Stun;
    public bool Posion;
    private float PosionDamage;
    public bool paralysis;

    private void Awake()
    {
        HP = MaxHP;
        HpPercent = HP / (MaxHP / 100);
        SliderHP = SliderHpObject.transform.GetChild(0).GetComponent<Slider>();
        BasicSpeed = Speed;

        Hit = false;
        Slow = false;
        Stun = false;
        Posion = false;
    }

    private void Start()
    {
       
        switch (CharacterType)
        {
            case ObjectType.Player:
                {
                    PL_Manager = GetComponent<PlayerManager>();
                    PL_Manager.attackSpeed = AttackSpeed;
                }
                break;
            case ObjectType.Monster:
                {
                    
                    Nav = GetComponent<NavMeshAgent>();
                    Nav.speed = Speed;
                    _MonsterState = GetComponent<MonsterState>();
                }
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        HpPercent = HP / (MaxHP / 100);

        switch (CharacterType)
        {
            case ObjectType.Player:
                {
                    PL_Manager.attackPower = AttackPower;
                    
                    //스피드
                    if (!Slow) Speed = BasicSpeed;
                    PL_Manager.PlayerSpeed = Speed;

                }
                break;
            case ObjectType.Monster:
                {
                    SliderHP.value = HpPercent;
                    //스피드
                    if (!Slow) { Speed = BasicSpeed; }
                    Nav.speed = Speed;

                    //지속 데미지
                    if (Posion){HP -= PosionDamage * Time.deltaTime;  }

                    if (HP <= 0)
                    {
                        SliderHP.gameObject.SetActive(false);
                        _MonsterState.Die = true;
                    }
                }
                break;
            default:
                break;
        }

    }

    public void colorChange(Color _Coler)
    {
        int Ccount = gameObject.transform.childCount;
        GameObject[] Child = new GameObject[Ccount];

        for (int i = 0; i < Ccount - 1; i++)
        {
            Child[i] = transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < Ccount - 1; i++)
        {
            Child[i].GetComponent<Renderer>().material.color = _Coler;
        }
    }

    public IEnumerator StatusHit(float Hit_Damage)
    {
        HP -= Hit_Damage;

        colorChange(Color.red);
        yield return new WaitForSeconds(0.2f);
        Hit = false;
        colorChange(Color.white);
    }
    
    private float BestSlowvalue = 0;
    public IEnumerator StatusSlow(float _Slow_value, float _Slow_Time)
    {
        if (BestSlowvalue < _Slow_value)
        {
            BestSlowvalue = _Slow_value;
        }
        float SecSlow = (BasicSpeed / 100) * (100 - _Slow_value);
        
        Speed = SecSlow;

        Slow = true;
        colorChange(Color.blue);
        yield return new WaitForSeconds(_Slow_Time);
        Slow = false;
        colorChange(Color.white);
    }

    public IEnumerator StatusPosion(float Posion_Damage, float Posion_Time)
    {
        PosionDamage = Posion_Damage;

        Posion = true;
        colorChange(Color.green);

        yield return new WaitForSeconds(Posion_Time);
        Posion = false;
        colorChange(Color.white);
    }
}