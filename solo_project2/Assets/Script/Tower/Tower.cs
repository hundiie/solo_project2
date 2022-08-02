using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TOWER
{
    NOMAL,
    ICE,
    POSION,
    DEATH
}

public class Tower : MonoBehaviour
{
    public TOWER TOWER;

    [SerializeField] private GameObject TowerManager;
    [SerializeField] private GameObject LaunchLocation;
    private TowerManager _TM;

    [HideInInspector] public GameObject TowerObject;
    [HideInInspector] public GameObject projectile;

    [HideInInspector] public float Money;
    [HideInInspector] public float UpgradeMoney;

    [HideInInspector] public float AttackPower;
    [HideInInspector] public float UpgradeAttackPower;

    [HideInInspector] public float AttackSpeed;
    [HideInInspector] public float UpgradeAttackSpeed;

    [HideInInspector] public float AttackDistance;
    [HideInInspector] public float UpgradeAttackDistance;

    [Header("NONAL")]
    [Header("ICE")]
    [HideInInspector] public float ICE_Slow;
    [HideInInspector] public float Upgrade_ICE_Slow;

    [Header("POSION")]
    [HideInInspector] public float POSION_Time;
    [HideInInspector] public float Upgrade_POSION_Time;

    [Header("DEATH")]
    [HideInInspector] public float DEATH_Percent;
    [HideInInspector] public float Upgrade_DEATH_Percent;


    private Transform Tagetting;

    private void Awake()
    {
        TowerDataMove();
    }

    private void Update()
    {
        Shot();
    }

    void TowerDataMove()
    {
        _TM = TowerManager.GetComponent<TowerManager>();

        TowerObject = _TM.Tower[(int)TOWER];
        projectile = _TM.projectile[(int)TOWER];

        Money = _TM.Money[(int)TOWER];
        UpgradeMoney = _TM.UpgradeMoney[(int)TOWER];

        AttackPower = _TM.AttackPower[(int)TOWER];
        UpgradeAttackPower = _TM.UpgradeAttackPower[(int)TOWER];

        AttackSpeed = _TM.AttackSpeed[(int)TOWER];
        UpgradeAttackSpeed = _TM.UpgradeAttackSpeed[(int)TOWER];

        AttackDistance = _TM.AttackDistance[(int)TOWER];
        UpgradeAttackDistance = _TM.UpgradeAttackDistance[(int)TOWER];

        switch (TOWER)
        {
            case TOWER.NOMAL:
                {

                }
                break;
            case TOWER.ICE:
                {
                    ICE_Slow = _TM.ICE_Slow;
                    Upgrade_ICE_Slow = _TM.Upgrade_ICE_Slow;
                }
                break;
            case TOWER.POSION:
                {
                    POSION_Time = _TM.POSION_Time;
                    Upgrade_POSION_Time = _TM.Upgrade_POSION_Time;
                }
                break;
            case TOWER.DEATH:
                {
                    DEATH_Percent = _TM.DEATH_Percent;
                    Upgrade_DEATH_Percent = _TM.Upgrade_DEATH_Percent;
                }
                break;
            default:
                break;
        }
    }

    float Delta = 0;
    bool check = false;
    private void Shot()
    {
        Delta += Time.deltaTime;
        if (Delta >= AttackSpeed && check == true)
        {
            Delta = 0f;
            LaunchLocation.transform.LookAt(Tagetting);
            GameObject bullet = Instantiate(projectile, LaunchLocation.transform.position, LaunchLocation.transform.rotation);
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
            Tagetting = other.transform;
            check = false;
        }
    }

}
