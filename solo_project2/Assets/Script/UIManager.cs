using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject TOWER_UI;
    [HideInInspector] public bool _TOWER_UI;

    public GameObject SELL_UI;
    [HideInInspector] public bool _SELL_UI;

    public GameObject UPGRADE_UI;
    [HideInInspector] public bool _UPGRADE_UI;

    private void Start()
    {
        _TOWER_UI = false;
        _SELL_UI = false;
        _UPGRADE_UI = false;
    }

    private void Update()
    {
        TOWER_UI.SetActive(_TOWER_UI);
        SELL_UI.SetActive(_SELL_UI);
        Debug.Log($"_UPGRADE_UI : {_UPGRADE_UI}");
        UPGRADE_UI.SetActive(_UPGRADE_UI);
    }
}