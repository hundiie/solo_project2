using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject GOLD_UI;
    [HideInInspector] public bool _GOLD_UI;
    public TextMeshProUGUI GoldUI;

    public GameObject TOWER_UI;
    [HideInInspector] public bool _TOWER_UI;

    public GameObject UPGRADE_UI;
    [HideInInspector] public bool _UPGRADE_UI;

    [Header("스테이터스 관련")]
    public GameObject STATUS_UI;
    [HideInInspector] public bool _STATUS_UI;
    public TextMeshProUGUI NameUI;
    public TextMeshProUGUI LevelUI;
    public TextMeshProUGUI AttackUI;
    public TextMeshProUGUI UpAttackUI;
    public TextMeshProUGUI AttackSpeedUI;
    public TextMeshProUGUI UpAttackSpeedUI;
    public TextMeshProUGUI DistanceUI;
    public TextMeshProUGUI UpDistanceUI;
    public TextMeshProUGUI UpgradeUI;
    public TextMeshProUGUI SellUI;

    [Header("라이프 관련")]
    public GameObject LIFE_UI;
    [HideInInspector] public bool _LIFE_UI;
    public TextMeshProUGUI LifeUI;

    [Header("라이프 관련")]
    public GameObject GAMEOVER_UI;
    [HideInInspector] public bool _GAMEOVER_UI;


    private void Start()
    {
        _TOWER_UI = false;
        _UPGRADE_UI = false;
        _STATUS_UI = false;
        _GOLD_UI = true;
        _LIFE_UI = true;
        _GAMEOVER_UI = false;
    }

    private void Update()
    {
        TOWER_UI.SetActive(_TOWER_UI);
        UPGRADE_UI.SetActive(_UPGRADE_UI);
        STATUS_UI.SetActive(_STATUS_UI);
        GOLD_UI.SetActive(_GOLD_UI);
        LIFE_UI.SetActive(_LIFE_UI);
        GAMEOVER_UI.SetActive(_GAMEOVER_UI);
    }

    public void Statusupdate(string name, int Level, float AttackPower, float UpAttackPower, float AttackSpeed, float UpAttackSpeed, float Distance, float UpDistance, float UpgradeMoney, int Sell)
    {
        NameUI.text = $"{name}";
        LevelUI.text = $"Level {Level}";
        AttackUI.text = $"{string.Format("{0:0.#}", AttackPower)}";
        UpAttackUI.text = $"+ {string.Format("{0:0.#}", UpAttackPower)}";
        AttackSpeedUI.text = $"{string.Format("{0:0.#}", AttackSpeed)}";
        UpAttackSpeedUI.text = $"- {string.Format("{0:0.#}", UpAttackSpeed)}";
        DistanceUI.text = $"{string.Format("{0:0.#}", Distance)}";
        UpDistanceUI.text = $"+ {string.Format("{0:0.#}", UpDistance)}";
        UpgradeUI.text = $"{string.Format("{0:0.#}", UpgradeMoney)}";
        SellUI.text = $"{string.Format("{0:0.#}", Sell)}";
    }
    private int InMoney;
    public void MoneyPlus(int Money)
    {
        InMoney += Money;
        MoneyUpdate(InMoney);
    }
    public void MoneyUpdate(int Money)
    {
        InMoney = Money;
        GoldUI.text = $"GOLD : {InMoney}";
    }
    
    private int InLife = 0;
    public void LifeUpdate(int Plus)
    {
        InLife += Plus;
        LifeUI.text = $" ♥ {InLife}";
    }

    public int GetLife()
    {
        return InLife;
    }
}