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
        //if (Move_Place == false)
        //{
        //    gameObject.GetComponent<BoxCollider>().enabled = false;
            
        //}
    }
}
