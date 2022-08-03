using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCreate : MonoBehaviour
{
    [HideInInspector] public GameObject HitObject;
    [SerializeField] private TextMeshProUGUI MoneyUI;
    private GameObject SaveObject;
    private Color BasicColor;
    public GameObject UI;

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
        
        Key_Push = false;
        Key_F = false;
    }

    void Update()
    {
        MoneyUI.text = $"GOLD : {Money}";

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
        BasicColor = TileColorSave(SaveObject);
        TileColorChange(SaveObject, Color.red);

        Debug.Log("들어오나1");
        if (!SaveObject.GetComponent<TileManager>().tower)
        {
            Debug.Log("들어오나2");
            UI.GetComponent<UIManager>()._TOWER_UI = true;
            TowerManager.transform.position = HitObject.transform.position;

        }
        else if (SaveObject.GetComponent<TileManager>().tower)
        {
            Debug.Log($"들어오나3 : {UI.GetComponent<UIManager>()._UPGRADE_UI}");
            UI.GetComponent<UIManager>()._UPGRADE_UI = true;
            Debug.Log($"들어오나4 : {UI.GetComponent<UIManager>()._UPGRADE_UI}");
        }
    }
    private void OutputKey_F()
    {
        Key_Push = false;
        Key_F = false;

        TileColorChange(SaveObject, BasicColor);
        UI.GetComponent<UIManager>()._TOWER_UI = false;
        UI.GetComponent<UIManager>()._UPGRADE_UI = false;
    }
    private void KeySet_F()
    {
        if (!SaveObject.GetComponent<TileManager>().tower)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OutputKey_F();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TowerCreate(0);
                OutputKey_F();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TowerCreate(1);
                OutputKey_F();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                TowerCreate(2);
                OutputKey_F();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                TowerCreate(3);
                OutputKey_F();
            }
        }
        else if (SaveObject.GetComponent<TileManager>().tower)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OutputKey_F();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                SaveObject.GetComponent<TileManager>().TowerObject.GetComponent<Tower>().TowerLevel += 1;
                SaveObject.GetComponent<TileManager>().TowerObject.transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
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

    Color TileColorSave(GameObject _gameObject)
    {
        return _gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color;
    }
    void TileColorChange(GameObject _gameObject, Color _color)
    {
        _gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = _color;
    }

    void SellTower()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI.GetComponent<UIManager>()._SELL_UI = false;
        }
    }

}
