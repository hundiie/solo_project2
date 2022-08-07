using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterState : MonoBehaviour
{
    private NavMeshAgent agent;
    private CharacterStatus status;
    private Bullet _Bullet;
    public GameObject Coin;
    [HideInInspector] public bool Die;
    [HideInInspector] public int DropMoney;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<CharacterStatus>();
        Die = false;
    }

    void Update()
    {
        if (Die)
        {
            MonsterDie();
        }
    }
    private bool InCoin = false;
    public void MonsterDie()
    {
        agent.speed = 0;
        if (!InCoin)
        {
            float floatCoin = (float)DropMoney;
            GameObject CoinMoney = Instantiate(Coin, transform.position += new Vector3(0, 0.15f + (floatCoin / 200f), 0), transform.rotation = Quaternion.Euler(0, 0, 90));
            CoinMoney.GetComponent<Coin>().PlusMoney = DropMoney;
            InCoin = true;
        }
        Destroy(gameObject,0.2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _Bullet = other.GetComponent<Bullet>();
            switch (other.name)
            {
                case "Bullet1(Clone)":
                    {
                        StartCoroutine(status.StatusHit(_Bullet.AttackPower));
                    }
                    break;

                case "Bullet2(Clone)":
                    {
                        status.HP -= _Bullet.AttackPower;
                        StartCoroutine(status.StatusSlow(_Bullet.ICE_Slow, _Bullet.ICE_Time));
                    }
                    break;

                case "Bullet3(Clone)":
                    {
                        StartCoroutine(status.StatusPosion(_Bullet.AttackPower, _Bullet.POSION_Time));
                    }
                    break;

                case "Bullet4(Clone)":
                    {
                        status.HP -= _Bullet.AttackPower;
                        StartCoroutine(status.StatusDeath(_Bullet.DEATH_Percent));
                    }
                    break;

                default:
                    break;
            }
            Destroy(other.gameObject);
        }
    }

}
