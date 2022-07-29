using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TOWER
{
    NOMAL,
    SLOW,
}
public class Tower : MonoBehaviour
{
    public TOWER _TOWER;
    
    [SerializeField]
    private GameObject[] TOWER = new GameObject[0];



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
