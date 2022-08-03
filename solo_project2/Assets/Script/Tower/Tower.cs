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
    
    private List<GameObject> TagetEnemys = new List<GameObject>();

    [SerializeField] private GameObject TowerManager;
    [SerializeField] private GameObject LaunchLocation;
    private TowerManager _TM;
    private Bullet _bullet;
    [HideInInspector] public int TowerLevel;

    [HideInInspector] public GameObject TowerObject;
    [HideInInspector] public GameObject _Bullet;

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
    [HideInInspector] public float ICE_Time;
    [HideInInspector] public float Upgrade_ICE_Time;

    [Header("POSION")]
    [HideInInspector] public float POSION_Time;
    [HideInInspector] public float Upgrade_POSION_Time;

    [Header("DEATH")]
    [HideInInspector] public float DEATH_Percent;
    [HideInInspector] public float Upgrade_DEATH_Percent;

    private Transform Tagetting;

    private void Awake()
    {
        TowerLevel = 1;

        TowerDataMove();
        BulletDataMove();
    }

    private float ShotDelta = 0f;
    private void Update()
    {
        gameObject.GetComponent<SphereCollider>().radius = AttackDistance + ((TowerLevel - 1) * UpgradeAttackDistance);
        ShotDelta += Time.deltaTime;
        Debug.Log($"TagetEnemys.Count : {TagetEnemys.Count}");
        if (TagetEnemys.Count > 0 && ShotDelta >= AttackSpeed)
        {
            ShotDelta = 0f;
            Shot();
             
        }
    }

    private void TowerDataMove()
    {
        _TM = TowerManager.GetComponent<TowerManager>();

        TowerObject = _TM.Tower[(int)TOWER];
        _Bullet = _TM.Bullet[(int)TOWER];

        Money = _TM.Money[(int)TOWER];
        UpgradeMoney = _TM.UpgradeMoney[(int)TOWER];

        AttackPower = _TM.AttackPower[(int)TOWER];
        UpgradeAttackPower = _TM.UpgradeAttackPower[(int)TOWER];

        AttackSpeed = _TM.AttackSpeed[(int)TOWER];
        UpgradeAttackSpeed = _TM.UpgradeAttackSpeed[(int)TOWER];

        AttackDistance = _TM.AttackDistance[(int)TOWER];
        UpgradeAttackDistance = _TM.UpgradeAttackDistance[(int)TOWER];
        gameObject.GetComponent<SphereCollider>().radius = AttackDistance + ((TowerLevel - 1) * UpgradeAttackDistance);

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
                    ICE_Time = _TM.ICE_Time;
                    Upgrade_ICE_Time = _TM.Upgrade_ICE_Time;
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

    private void BulletDataMove()
    {
        _bullet = _Bullet.GetComponent<Bullet>();
        _bullet.TowerPosition = transform.position;

        _bullet.TOWER = TOWER;
        _bullet.AttackPower = AttackPower + ((TowerLevel - 1) * UpgradeAttackPower);
        _bullet.AttackDistance = AttackDistance + ((TowerLevel - 1) * UpgradeAttackDistance);

        switch (TOWER)
        {
            case TOWER.NOMAL:
                {

                }
                break;
            case TOWER.ICE:
                {
                    _bullet.ICE_Slow = ICE_Slow + ((TowerLevel - 1) * Upgrade_ICE_Slow);
                    _bullet.ICE_Time = ICE_Time + ((TowerLevel - 1) * Upgrade_ICE_Time);
                }
                break;
            case TOWER.POSION:
                {
                    _bullet.POSION_Time = POSION_Time + ((TowerLevel - 1) * Upgrade_POSION_Time);
                }
                break;
            case TOWER.DEATH:
                {
                    _bullet.DEATH_Percent = DEATH_Percent + ((TowerLevel - 1) * Upgrade_DEATH_Percent);
                }
                break;
            default:
                break;
        }
    }

    private void Shot()
    {
        for (int i = 0; i < TagetEnemys.Count; i++)
        {
            if (TagetEnemys[i] != null)
            {
                _bullet.TargetPosition = (TagetEnemys[i].transform.position - transform.position).normalized;
                LaunchLocation.transform.LookAt(TagetEnemys[i].transform);
                Instantiate(_Bullet, LaunchLocation.transform.position, Quaternion.identity, transform);
                break;
            }
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            TagetEnemys.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject go in TagetEnemys)
        {
            if (go == other.gameObject)
            {
                TagetEnemys.Remove(go);
                break;
            }
        }
    }

}
