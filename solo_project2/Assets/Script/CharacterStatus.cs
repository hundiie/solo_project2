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
    [Header("Monster")]
    public int DropMoney;

    //플레이어 관련
    private PlayerManager PL_Manager;
    //공용
    private Animator _Animator;

    [Header("HP")]
    public float MaxHP;
    [HideInInspector] public float HP;
    [HideInInspector] public float HpPercent;

    [Header("Speed")]
    public float Speed;
    [HideInInspector] public float BasicSpeed;
    private NavMeshAgent Nav;

    [Header("Attack")]
    public float AttackPower;
    public float AttackSpeed;


    [Header("Debuff")]
    public bool Hit;//0

    public bool Slow;//1
    private float SecSlow;
    
    public bool Stun;//2
    
    public bool Posion;//3
    private float PosionDamage;

    public bool death;//4


    [Header("buff 아직 미구현")]
    
    public bool HpUp;//0
    public bool MoveSpeedUp;//0
    public bool AttackSpeedUp;//0

    [HideInInspector] public Camera cameraToLookAt;
    [HideInInspector] public GameObject hpp;

    private void Awake()
    {
        HP = MaxHP;
        HpPercent = HP / (MaxHP / 100);
        SliderHP = SliderHpObject.transform.GetChild(0).GetComponent<Slider>();
        _Animator = GetComponent<Animator>();
        
        BasicSpeed = Speed;

        Hit = false;
        Slow = false;
        Stun = false;
        Posion = false;
    }

    private void Start()
    {
        cameraToLookAt = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
                    GetComponent<MonsterState>().DropMoney = DropMoney;
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
        
        hpp.transform.LookAt(cameraToLookAt.transform);
        
        switch (CharacterType)
        {
            case ObjectType.Player:
                {
                    PL_Manager.attackPower = AttackPower;

                    StatusMove();

                }
                break;
            case ObjectType.Monster:
                {
                    StatusMove();
                    SliderHP.value = HpPercent;
                    
                    if (HP <= 0)
                    {
                        SliderHP.gameObject.SetActive(false);
                        _MonsterState.Die = true;
                    }

                    Nav.speed = Speed;
                }
                break;
            default:
                break;
        }

    }

    public void StatusMove()
    {
        //---------- 같은 오브젝트 관리

        //피격
        if (Hit) { }
        else if (!Hit) { }
        
        //스턴
        if (Stun) { Speed = 0; _Animator.enabled = false; }
        else if (!Stun) { _Animator.enabled = true; }

        //독
        if (Posion) { HP -= PosionDamage * Time.deltaTime; }
        else if (!Posion) { }

        //즉사
        if (death) { HP = 0; }
        else if (!death) { }


        //---------- 다른 오브젝트 관리

        switch (CharacterType)
        {
            case ObjectType.Player:
                {
                    PL_Manager.attackPower = AttackPower;

                    //슬로우
                    if (Slow) { Speed = SecSlow; }
                    else { Speed = BasicSpeed; }
                    PL_Manager.PlayerSpeed = Speed;

                }
                break;
            case ObjectType.Monster:
                {
                    //슬로우
                    if (Slow) { Speed = SecSlow; }
                    else if (!Slow) { Speed = BasicSpeed; }
                    Nav.speed = Speed;
                }
                break;
            default:
                break;
        }

}

    public void colorChange(Color _Coler)
    {
        if (gameObject != null) 
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
    }

    /// <summary>
    /// (디버프) 피격
    /// </summary>
    /// <param name="Hit_Damage"> 피격 데미지 </param>
    /// <returns></returns>
    public IEnumerator StatusHit(float Hit_Damage)
    {
        HP -= Hit_Damage;
        Hit = true;
        colorChange(Color.red);
        yield return new WaitForSeconds(0.2f);
        Hit = false;
        colorChange(Color.white);
    }

    /// <summary>
    /// (디버프) 슬로우
    /// </summary>
    private float BestSlowvalue = 0;
    public IEnumerator StatusSlow(float _Slow_value, float _Slow_Time)
    {
        if (BestSlowvalue < _Slow_value)
        {
            BestSlowvalue = _Slow_value;
        }

        SecSlow = (BasicSpeed / 100) * (100 - _Slow_value);
        
        Slow = true;
        colorChange(Color.blue);
        
        yield return new WaitForSeconds(_Slow_Time);
        
        Slow = false;
        colorChange(Color.white);
        
        BestSlowvalue = 0;
    }

    /// <summary>
    /// (디버프) 스턴
    /// </summary>
    /// <param name="_Stun_Time">스턴 시간</param>
    /// <returns></returns>
    public IEnumerator StatusStun(float _Stun_Time)
    {
        Speed = 0;

        Stun = true;
        
        yield return new WaitForSeconds(_Stun_Time);

        Stun = false;

        BestSlowvalue = 0;
    }

    /// <summary>
    /// (디버프) 독
    /// </summary>
    /// <param name="Posion_Damage"> 초당 독 데미지 </param>
    /// <param name="Posion_Time"> 독 지속시간 </param>
    /// <returns></returns>
    public IEnumerator StatusPosion(float Posion_Damage, float Posion_Time)
    {
        PosionDamage = Posion_Damage;

        Posion = true;
        colorChange(Color.green);

        yield return new WaitForSeconds(Posion_Time);
        Posion = false;
        colorChange(Color.white);
    }

    /// <summary>
    /// (디버프) 즉사
    /// </summary>
    /// <param name="Death_Percent"> 즉사 확률 </param>
    /// <returns></returns>
    public IEnumerator StatusDeath(float Death_Percent)
    {
        float RandomFloat = Random.Range(0.0f, 100.0f);
        if (RandomFloat < Death_Percent)
        {
            death = true;
            colorChange(Color.black);
            yield return new WaitForSeconds(0.1f);

            death = false;
        }
    }
}