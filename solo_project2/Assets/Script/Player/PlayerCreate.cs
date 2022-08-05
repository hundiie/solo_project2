using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCreate : MonoBehaviour
{
    [HideInInspector] public GameObject HitObject;
    private GameObject SaveObject;
    public GameObject UI;
    UIManager UI_Manager;
    [Header("PLAYER")]
    public int Money;
    
    [Header("TOWER")]
    public GameObject TowerManager;
    private TowerManager _TM;

    //KEY
    private bool Key_Push;
    private bool Key_F;


    private void Start()
    {
        _TM = TowerManager.GetComponent<TowerManager>();
        UI_Manager = UI.GetComponent<UIManager>();
        UI_Manager.Moneyupdate(Money);
        Key_Push = false;
        Key_F = false;
    }

    void Update()
    {
        if (HitObject != null)
        {
            switch (HitObject.tag)
            {
                case "Tile":
                    {
                        CreateInput();
                    }
                    break;
                case "Tower":
                    {
                    }
                    break;
                default:
                    break;
            }
        }
    }
    
    void CreateInput()
    {
        if (HitObject.GetComponent<TileManager>().build_Place)
        {
            if (Input.GetKeyDown(KeyCode.F) && !Key_Push)
            {
                InputKey_F();
            }
        }

        if (Key_Push)
        {
            if (Key_F)
            {
                KeySet_F();
            }
        }
    }

    private void InputKey_F()
    {
        Key_Push = true;
        Key_F = true;

        SaveObject = HitObject;
        TileColorChange(SaveObject, Color.red);

        if (!SaveObject.GetComponent<TileManager>().tower)
        {
            UI_Manager._TOWER_UI = true;
            TowerManager.transform.position = HitObject.transform.position;

        }
        else if (SaveObject.GetComponent<TileManager>().tower)
        {
            Tower towerData = SaveObject.GetComponent<TileManager>().TowerObject.GetComponent<Tower>();

            float _attackPower = towerData.AttackPower + ((towerData.TowerLevel - 1) * towerData.UpgradeAttackPower);
            float _attackSpeed = towerData.AttackSpeed - ((towerData.TowerLevel - 1) * towerData.UpgradeAttackSpeed);
            float _attackDistance = towerData.AttackDistance + ((towerData.TowerLevel - 1) * towerData.UpgradeAttackDistance);
            string _towerName = "";
            switch (towerData.TOWER)
            {
                case TOWER.NOMAL:
                    _towerName = "NOMAL";
                    break;
                case TOWER.ICE:
                    _towerName = "ICE";
                    break;
                case TOWER.POSION:
                    _towerName = "POSION";
                    break;
                case TOWER.DEATH:
                    _towerName = "DEATH";
                    break;
                default:
                    break;
            }


            UI_Manager._STATUS_UI = true;
            UI_Manager.Statusupdate(_towerName, towerData.TowerLevel, _attackPower, towerData.UpgradeAttackPower, _attackSpeed, towerData.UpgradeAttackSpeed, _attackDistance, towerData.UpgradeAttackDistance, towerData.UpgradeMoney);

            UI_Manager._UPGRADE_UI = true;
        }
    }
    private void OutputKey_F()
    {
        Key_Push = false;
        Key_F = false;

        TileColorChange(SaveObject, Color.white);
        UI_Manager._TOWER_UI = false;
        UI_Manager._UPGRADE_UI = false;
        UI_Manager._STATUS_UI = false;
        UI_Manager.Moneyupdate(Money);
    }
    private void KeySet_F()
    {
        int needMoney;
        if (!SaveObject.GetComponent<TileManager>().tower)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OutputKey_F();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                needMoney = _TM.Money[0];
                if (Money >= needMoney)
                {
                    Money -= needMoney;
                    TowerCreate(0);
                }
                OutputKey_F();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                needMoney = _TM.Money[1];
                if (Money >= needMoney)
                {
                    Money -= needMoney;
                    TowerCreate(1);
                }
                OutputKey_F();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                needMoney = _TM.Money[2];
                if (Money >= needMoney)
                {
                    Money -= needMoney;
                    TowerCreate(2);
                }
                OutputKey_F();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                needMoney = _TM.Money[3];
                if (Money >= needMoney)
                {
                    Money -= needMoney;
                    TowerCreate(3);
                }
                OutputKey_F();
            }
        }
        else if (SaveObject.GetComponent<TileManager>().tower)
        {
            int needUpgread;
            int maxLevel = SaveObject.GetComponent<TileManager>().TowerObject.GetComponent<Tower>().MaxLevel;
            int TowerLevel = SaveObject.GetComponent<TileManager>().TowerObject.GetComponent<Tower>().TowerLevel;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OutputKey_F();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                Destroy(SaveObject.GetComponent<TileManager>().TowerObject);
                SaveObject.GetComponent<TileManager>().tower = false;
                Money += 10;
                OutputKey_F();
            }
            if (Input.GetKeyDown(KeyCode.G) && maxLevel >TowerLevel)
            {
                needUpgread = SaveObject.GetComponent<TileManager>().TowerObject.GetComponent<Tower>().UpgradeMoney;

                if (Money >= needUpgread)
                {
                    Money -= needUpgread;

                    SaveObject.GetComponent<TileManager>().TowerObject.GetComponent<Tower>().TowerLevel += 1;
                    SaveObject.GetComponent<TileManager>().TowerObject.transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
                }
                OutputKey_F();
            }
        }
    }
    private void TowerCreate(int TowerNumer)
    {
        GameObject TOWER_OBJECT = Instantiate(_TM.Tower[TowerNumer], SaveObject.transform.position, transform.rotation);
        SaveObject.GetComponent<TileManager>().tower = true;
        SaveObject.GetComponent<TileManager>().TowerObject = TOWER_OBJECT;

    }

    void TileColorChange(GameObject _gameObject, Color _color)
    {
        _gameObject.GetComponent<Renderer>().material.color = _color;
    }
}
