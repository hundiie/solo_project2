using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject _Spawner;
    public float[] Spawner = new float[3];

    public GameObject _End;
    public float[] End = new float[3];

    void Start()
    {
        Instantiate(_Spawner, new Vector3(Spawner[0], Spawner[1], Spawner[2]), transform.rotation);
        Instantiate(_End, new Vector3(End[0], End[1], End[2]), transform.rotation);
    }
}
