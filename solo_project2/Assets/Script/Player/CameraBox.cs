using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBox : MonoBehaviour
{
    public GameObject movement;

    void Update()
    {
        transform.position = movement.transform.position;
        
    }
}
