using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 _CameraCenter;

    private float MouseX;
    private float MouseY;

    [SerializeField]private float MouseSpeed;

    [Header("Object")]
    public GameObject CameraBox;
    public GameObject Player;
    private void Start()
    {
        _CameraCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    void Update()
    {
        CrameraMove();
        CrameraCenter();
    }

    private void CrameraMove()
    {
        MouseX += Input.GetAxis("Mouse X") * MouseSpeed;
        MouseY += Input.GetAxis("Mouse Y") * MouseSpeed;
        MouseY = Mathf.Clamp(MouseY, -45f, 45f);
        CameraBox.transform.eulerAngles = new Vector3(-MouseY, MouseX, 0);
    }

    void CrameraCenter()
    {
        Ray ray = Camera.main.ScreenPointToRay(_CameraCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.transform.parent.tag == "Tile")
            {
                Player.GetComponent<PlayerCreate>().HitObject = hit.collider.gameObject.transform.parent.gameObject;
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);
    }
}
