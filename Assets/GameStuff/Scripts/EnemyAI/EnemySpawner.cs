using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int NumberOfEnemy;
    [SerializeField] GameObject[] listOfenemy;
    [SerializeField] List<PatrolList> patrolLists = new List<PatrolList>();
    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        listOfenemy = new GameObject[NumberOfEnemy];
        Debug.Log("start");
        StartCoroutine("Check");
    }

    IEnumerator Check()
    {
        while (true)
        {
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
                    System.Random rnd = new System.Random();
                    int h = rnd.Next(0, patrolLists.Count);
                    listOfenemy[i] = Instantiate(EnemyPrefab, transform.position, transform.rotation);
                    listOfenemy[i].GetComponent<Patrol>().SetPatrolList(patrolLists[h].getList(), patrolLists[h].getWait());
                }
                yield return new WaitForSeconds(10);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
