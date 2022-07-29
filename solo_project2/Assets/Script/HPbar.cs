using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    private GameObject Taget;
    private MonsterState _MonsterState;

    public Slider _slider;

    void Start()
    {
        Taget = transform.parent.GetComponent<GameObject>();

        if (Taget.tag == "Monster")
        {
            _MonsterState = Taget.GetComponent<MonsterState>();
        }
    }

    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(Taget.transform.position) + new Vector3(0, 0, 0);
        _slider.value = _MonsterState.HPpercent;
    }
}
