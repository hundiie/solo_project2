using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreate : MonoBehaviour
{
    private Vector3 CameraCenter;

    void Start()
    {
        CameraCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    // Update is called once per frame
    void Update()
    {
        CAMERASENTER();
    }


    void CAMERASENTER()
    {
        Ray ray = Camera.main.ScreenPointToRay(CameraCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log($" hit point : {hit.point}");
        }

        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);
    }
}
