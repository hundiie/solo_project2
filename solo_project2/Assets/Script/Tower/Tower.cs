using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TOWER
{
    NOMAL,
    SLOW,
    POISON
}
public class Tower : MonoBehaviour
{
    public TOWER _TOWER;

    [Header("NONAL")]//평타 타워
    public bool NOMAL;
    public float NOMAL_Power;
    public float NOMAL_AttackSpeed;
    public GameObject NOMAL_projectile;

    [Header("ICE")]//슬로우 거는 타워
    public bool ICE;
    public float ICE_Power;
    public float ICE_AttackSpeed;
    public float ICE_Slow;
    public GameObject ICE_projectile;

    [Header("POSION")]//슬로우 거는 타워
    public bool POSION;
    public float POSION_Power;
    public float POSION_AttackSpeed;
    public float POSION_Time;
    public GameObject POSION_projectile;

    private float Delta;
    private Transform Tagetting;
    private bool check = false;
    void Update()
    {
        Delta += Time.deltaTime;
        if (Delta >= 0.5f&& check == true)
        {
            Delta = 0;
            gameObject.transform.LookAt(Tagetting);
            GameObject bullet = Instantiate(NOMAL_projectile, transform.position, transform.rotation);
            bullet.transform.LookAt(Tagetting);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            Tagetting = other.transform;
            check = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Monster")
        {
            check = false;
        }
    }
}
