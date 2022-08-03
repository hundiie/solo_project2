using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [Header("Build possible?")]
    public bool build_Place;
    [HideInInspector] public bool tower = false;
    [HideInInspector] public GameObject TowerObject;

    [Header("Move possible?")]
    public bool Move_Place;

    private void Start()
    {
        if (Move_Place == false)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = false;
            } 
        }
    }
    private void Update()
    {
        
    }

}
