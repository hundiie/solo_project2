using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //[HideInInspector]
    public int PlusMoney;

    void Start()
    {
        float floatMoney = (float)PlusMoney;
        transform.localScale = new Vector3(0.3f + (floatMoney / 100), 0.01f, 0.3f + (PlusMoney / 100));
        
        Destroy(gameObject, 120.0f);
    }
    private float CoinMotion = 0;
    void Update()
    {
        transform.Rotate(5, 0, 0);
        
        CoinMotion += Time.deltaTime;

        if (CoinMotion <= 0.5f)
        {
            transform.position += new Vector3(0, 4f * Time.deltaTime, 0);
        }
        else if (CoinMotion <= 1f)
        {
            transform.position += new Vector3(0, -4f * Time.deltaTime, 0);

        }
    }
}
