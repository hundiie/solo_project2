using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMake : MonoBehaviour
{
    public GameObject[] Map = new GameObject[0];

    [HideInInspector] public bool[] MapSwitch;
    
    [Header ("Spawner")]
    public GameObject _Spawner;
    public GameObject[] SpawnerObject;
    
    public float[] _SpawnerX = new float[0];
    public float[] _SpawnerY = new float[0];
    public float[] _SpawnerZ = new float[0];

    
    [Header("End")]
    public GameObject _End;
    public GameObject[] EndObject;

    public float[] _EndX = new float[0];
    public float[] _EndY = new float[0];
    public float[] _EndZ = new float[0];


    private void Awake()
    {
        int mapNumber = Map.Length;
        MapSwitch = new bool[mapNumber];
        SpawnerObject = new GameObject[mapNumber];
        EndObject = new GameObject[mapNumber];

        MapSwitch[0] = true;
        for (int i = 0; i < Map.Length; i++)
        {
            Map[i].SetActive(MapSwitch[i]);
        }

        createSpawner(0);
        createEnd(0);
    }

    private void createSpawner(int NUM)
    {
        Vector3 SpawnerTransfrom = new(_SpawnerX[NUM], _SpawnerY[NUM], _SpawnerZ[NUM]);
        SpawnerObject[NUM] = Instantiate(_Spawner, SpawnerTransfrom,transform.rotation);
    }

    private void createEnd(int NUM)
    {
        Vector3 EndTransfrom = new(_EndX[NUM], _EndY[NUM], _EndZ[NUM]);
        EndObject[NUM] = Instantiate(_End, EndTransfrom, transform.rotation);
    }

   public void createMap(int NUM)
    {
        Map[NUM].SetActive(true);
        createSpawner(NUM);
    }

    private void DeleteMap(int NUM)
    {
        Map[NUM].SetActive(false);
        Destroy(SpawnerObject[NUM]);
    }

}
