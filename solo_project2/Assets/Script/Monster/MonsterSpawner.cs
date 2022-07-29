using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private float SpawnerDelay;
    [SerializeField]
    private GameObject[] Monster = new GameObject[0];

    void Start()
    {
        
    }
    
    void Update()
    {
        SPAWNER();
    }

    private float spawnerTime;
    private void SPAWNER()
    {
        spawnerTime += Time.deltaTime;
        if (spawnerTime >= SpawnerDelay)
        {
            int ran = Random.Range(0, 5);
            spawnerTime = 0.0f;
            Instantiate(Monster[ran], transform.position, transform.rotation);
        }
    }
}
