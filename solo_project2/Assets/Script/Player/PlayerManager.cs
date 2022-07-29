using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CharacterController PLAYER;
    private MonsterState _MonsterState;
    private SWORD _sword;
    private Animator ANI;

    [SerializeField]
    private GameObject CAMERA;
    [SerializeField]
    private GameObject Sword;

    public float PlayerSpeed;
    public float JumpSpeed;

    private int attackMotion;
    public float attackSpeed;
    public float attackPower;

    private void Start()
    {
        PLAYER = GetComponent<CharacterController>();
        ANI = GetComponent<Animator>();
        _sword = Sword.GetComponent<SWORD>();
        attackMotion = 0;
    }

    private void Update()
    {
        
        PlayerMove();
        PlayerAttack();
    }

    private void PlayerMove()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            ANI.SetBool("MOVE", true);
            transform.forward = new Vector3(CAMERA.transform.forward.x, 0f, CAMERA.transform.forward.z).normalized;
        }
        else
        {
            ANI.SetBool("MOVE", false);
        }

        Vector3 _Move = new Vector3(MoveHorizontal, 0, MoveVertical);
        PLAYER.Move(transform.TransformDirection(_Move) * Time.deltaTime * PlayerSpeed);
    }

    private float attackTime;
    private void PlayerAttack()
    {
        attackTime += Time.deltaTime;
        _sword.attackPower = attackPower;
        if (ANI.GetCurrentAnimatorStateInfo(0).IsTag("ATTACK"))
        {
            _sword.attackMotioning = true;
        }
        else
        {
            _sword.attackMotioning = false;
        }

        if (Input.GetMouseButtonDown(0) && attackTime >= attackSpeed)
        {
            attackTime = 0f;
            
            attackMotion += 1;

            if (attackMotion > 1)
            {
                attackMotion = 0;
            }

            ANI.SetTrigger("ATTACK");
            ANI.SetInteger("AttackMotion", attackMotion);
        }
    }
}
