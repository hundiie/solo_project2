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
    // ���� ����
    private MonsterState _MonsterState;
    [SerializeField] private GameObject SliderHpObject;
    private Slider SliderHP;
    public ObjectType CharacterType;

    //�÷��̾� ����
    private PlayerManager PL_Manager;

    //����

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


    [Header("buff ���� �̱���")]
    
    public bool HpUp;//0
    public bool MoveSpeedUp;//0
    public bool AttackSpeedUp;//0


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
        //---------- ���� ������Ʈ ����

        //�ǰ�
        if (Hit) { }
        else if (!Hit) { }
        
        //����
        if (Stun) { Speed = 0; _Animator.enabled = false; }
        else if (!Stun) { _Animator.enabled = true; }

        //��
        if (Posion) { HP -= PosionDamage * Time.deltaTime; }
        else if (!Posion) { }

        //���
        if (death) { HP = 0; }
        else if (!death) { }


        //---------- �ٸ� ������Ʈ ����

        switch (CharacterType)
        {
            case ObjectType.Player:
                {
                    PL_Manager.attackPower = AttackPower;

                    //���ο�
                    if (Slow) { Speed = SecSlow; }
                    else { Speed = BasicSpeed; }
                    PL_Manager.PlayerSpeed = Speed;

                }
                break;
            case ObjectType.Monster:
                {
                    //���ο�
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

    /// <summary>
    /// (�����) �ǰ�
    /// </summary>
    /// <param name="Hit_Damage"> �ǰ� ������ </param>
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
    /// (�����) ���ο�
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
    /// (�����) ����
    /// </summary>
    /// <param name="_Stun_Time">���� �ð�</param>
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
    /// (�����) ��
    /// </summary>
    /// <param name="Posion_Damage"> �ʴ� �� ������ </param>
    /// <param name="Posion_Time"> �� ���ӽð� </param>
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
    /// (�����) ���
    /// </summary>
    /// <returns></returns>
    public IEnumerator StatusDeath()
    {
        death = true;

        yield return new WaitForSeconds(0.1f);
        
        death = false;

    }
}