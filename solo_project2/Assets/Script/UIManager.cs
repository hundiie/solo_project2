using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject TOWER_UI;
    public bool _TOWER_UI;

    public GameObject SELL_UI;
    public bool _SELL_UI;

    private void Start()
    {
        _TOWER_UI = false;
        _SELL_UI = false;
    }

    private void Update()
    {
        TowerUI();
        SellUI();
    }

    void TowerUI()
    {
        if (_TOWER_UI == true)
        {
            TOWER_UI.SetActive(true);
        }
        else
        {
            TOWER_UI.SetActive(false);
        }
    }

    void SellUI()
    {
        if (_SELL_UI == true)
        {
            SELL_UI.SetActive(true);
        }
        else
        {
            SELL_UI.SetActive(false);
        }
    }
}
