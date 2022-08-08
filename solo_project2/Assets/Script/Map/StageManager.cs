using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject Map;
    private MapMake _MapMake;
    [HideInInspector] public int nowStage;

    public float SpawnTime;

    public GameObject[] Monster = new GameObject[0];


    private int[] StageMonster; 
    private bool[] stageGo = new bool[30];
    private void Awake()
    {
        _MapMake = Map.GetComponent<MapMake>();
    }

    private int[,] Stage = new int[30, 31];
    private void Start()
    {

        //1 스테이지
        {
            UpdateMonster(1, 0, 0, 30);
        }

        //2 스테이지
        {
            UpdateMonster(2, 0, 0, 20);
            UpdateMonster(2, 1, 21, 30);
        }

        //3 스테이지
        {
            UpdateMonster(3, 0, 0, 10);
            UpdateMonster(3, 1, 11, 30);
        }

        //4 스테이지
        {
            UpdateMonster(4, 1, 0, 15);
            UpdateMonster(4, 2, 16, 30);
        }

        //5 스테이지
        {
            UpdateMonster(5, 1, 0, 10);
            UpdateMonster(5, 2, 11, 29);
            UpdateMonster(5, 5, 30, 30);
            _MapMake.createMap(1);
        }

        //6 스테이지
        {
            UpdateMonster(6, 2, 0, 15);
            UpdateMonster(6, 3, 16, 30);
        }

        //7 스테이지
        {
            UpdateMonster(7, 2, 0, 10);
            UpdateMonster(7, 3, 11, 20);
            UpdateMonster(7, 4, 21, 30);
        }

        //8 스테이지
        {
            UpdateMonster(8, 2, 0, 5);
            UpdateMonster(8, 3, 6, 20);
            UpdateMonster(8, 4, 21, 29);
            UpdateMonster(5, 5, 30, 30);
        }

        //9 스테이지
        {
            UpdateMonster(9, 3, 0, 20);
            UpdateMonster(9, 4, 21, 30);
        }

        //10 스테이지
        {
            UpdateMonster(10, 4, 0, 29);
            UpdateMonster(10, 6, 30, 30);
        }



    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(StageStart(nowStage));
            nowStage++;
        }
    }

    void UpdateMonster(int StageNUM, int MonsterNum,int start,int end)
    {
        for (int i = start; i <= end; i++)
        {
            Stage[StageNUM - 1 , i] = MonsterNum;
        }
    }

    IEnumerator StageStart(int GoStageNumber)
    {
        int MonsterCount = 0;
        int spawnerNumber = 0;
        for (int i = 0; i < _MapMake.SpawnerObject.Length; i++)
        {
            if(_MapMake.MapSwitch[i] == true)
            {
                spawnerNumber++;
            }
        }
        while (MonsterCount <= 30)
        {
            int RandomNum = Random.Range(0, spawnerNumber);
            Instantiate(Monster[Stage[GoStageNumber, MonsterCount]], _MapMake.SpawnerObject[RandomNum].transform.position, _MapMake.SpawnerObject[RandomNum].transform.rotation);

            MonsterCount++;
            yield return new WaitForSeconds(SpawnTime);
        }
    }


}
