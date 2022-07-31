using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreate : MonoBehaviour
{
    public GameObject HitObject;
    private GameObject SaveObject;
    public GameObject UI;

    [Header("TOWER")]
    [SerializeField]private GameObject[] TOWER = new GameObject[0];

    private bool Key_F;

    private void Start()
    {
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                Key_F = true;
                UI.GetComponent<UIManager>()._TOWER_UI = true;
                SaveObject = HitObject;
            }
        }

        if (Key_F)
        {
            TowerCreate();
        }
    }

    void TowerCreate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI.GetComponent<UIManager>()._TOWER_UI = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(TOWER[0], SaveObject.transform.position, SaveObject.transform.rotation);
            UI.GetComponent<UIManager>()._TOWER_UI = false;
            HitObject.GetComponent<TileManager>().build_Place = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(TOWER[1], SaveObject.transform.position, SaveObject.transform.rotation);
            UI.GetComponent<UIManager>()._TOWER_UI = false;
            HitObject.GetComponent<TileManager>().build_Place = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(TOWER[2], SaveObject.transform.position, SaveObject.transform.rotation);
            UI.GetComponent<UIManager>()._TOWER_UI = false;
            HitObject.GetComponent<TileManager>().build_Place = false;
        }
    }

    void SellCreate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI.GetComponent<UIManager>()._SELL_UI = false;
        }
    }

}
