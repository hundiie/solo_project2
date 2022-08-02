using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class PlayerCreate : MonoBehaviour
{
    [HideInInspector] public GameObject HitObject;
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
        if (HitObject !=null)
        {
            CreateInput();        
        }
    }
    
    void CreateInput()
    {
        if (HitObject.GetComponent<TileManager>().build_Place)
        {
            if (Input.GetKeyDown(KeyCode.F) && !Key_Push)
            {
                Key_Push = true;
                Key_F = true;

                InputKey_F();
            }
        }

        if (Key_Push && Key_F)
        {
            KeySet_F();
        }
    }

    private void InputKey_F()
    {
        UI.GetComponent<UIManager>()._TOWER_UI = true;
        TowerManager.transform.position = HitObject.transform.position;

        SaveObject = HitObject;
        BasicColor = TileColorSave(SaveObject);
        TileColorChange(SaveObject, Color.red);
    }
    private void OutputKey_F()
    {
        TileColorChange(SaveObject, BasicColor);
        UI.GetComponent<UIManager>()._TOWER_UI = false;
        Key_Push = false;
        Key_F = false;
    }


    Color TileColorSave(GameObject _gameObject)
    {
        return _gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color;
    }
    void TileColorChange(GameObject _gameObject, Color _color)
    {
        _gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = _color;
    }

    private void TowerCreate(int TowerNumer)
    {
        Instantiate(_TM.Tower[TowerNumer], SaveObject.transform.position, transform.rotation);
        SaveObject.GetComponent<TileManager>().build_Place = false;
    }

    void KeySet_F()
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

    void SellTower()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI.GetComponent<UIManager>()._SELL_UI = false;
        }
    }

}
