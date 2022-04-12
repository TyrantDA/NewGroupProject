using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public string PartyName;
    public GameObject EnemyPrefab;
    public GameObject EnemyRangedPrefab;
    public GameObject EnemyHealerPrefab;
    [SerializeField] GameObject[] listOfenemy;
    private int NumberOfEnemy = 3;

    // Start is called before the first frame update
    void Start()
    {
        listOfenemy = new GameObject[NumberOfEnemy];

    }

    public void SpawnEnemy(List<GameObject> patrolList, List<int> waitList, GameObject spawnPoint)
    {
        listOfenemy[0] =  Instantiate(EnemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        listOfenemy[0].GetComponent<Patrol>().SetPatrolList(patrolList, waitList);
    }

    public void SpawnEnemyRanged(List<GameObject> patrolList, List<int> waitList, GameObject spawnPoint)
    {
        listOfenemy[1] = Instantiate(EnemyRangedPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        listOfenemy[1].GetComponent<Patrol>().SetPatrolList(patrolList, waitList);
    }

    public void SpawnEnemyHealer(List<GameObject> patrolList, List<int> waitList, GameObject spawnPoint)
    {
        listOfenemy[2] = Instantiate(EnemyHealerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        listOfenemy[2].GetComponent<Patrol>().SetPatrolList(patrolList, waitList);
    }

    public int look()
    {
        int count = 0;
        for (int i = 0; i < NumberOfEnemy; i++)
        {
            try
            {
                GameObject hold = listOfenemy[i];
                Debug.Log("running" + hold);
                Transform hold2 = hold.transform;
            }
            catch (Exception e)
            {
                count++;
            }
        }
        return count;
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
