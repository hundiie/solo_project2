using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float MouseX;
    private float MouseY;
    [SerializeField]
    private float MouseSpeed;

    void Update()
    {
        CrameraMove();
    }

    private void CrameraMove()
    {
        MouseX += Input.GetAxis("Mouse X") * MouseSpeed;
        MouseY += Input.GetAxis("Mouse Y") * MouseSpeed;
        MouseY = Mathf.Clamp(MouseY, -45f, 45f);
        transform.eulerAngles = new Vector3(-MouseY, MouseX, 0);
    }
}
