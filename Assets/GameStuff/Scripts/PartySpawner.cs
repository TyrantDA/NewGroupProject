using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySpawner : MonoBehaviour
{
    [SerializeField] List<Party> listOfenemy = new List<Party>();
    [SerializeField] List<PatrolList> patrolLists = new List<PatrolList>();

    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;

    public int checkTime;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("Check");
    }

    void spawnParty(int i, int ss, int h)
    {
       

        if (ss == 0)
        {
            listOfenemy[i].SpawnEnemy(patrolLists[h].getList(), patrolLists[h].getWait(), spawnPoint1);
        }
        else if(ss == 1)
        {
            listOfenemy[i].SpawnEnemyRanged(patrolLists[h].getList(), patrolLists[h].getWait(), spawnPoint1);
        }
        else if(ss == 2)
        {
            listOfenemy[i].SpawnEnemyHealer(patrolLists[h].getList(), patrolLists[h].getWait(), spawnPoint1);
        }

    }
    IEnumerator Check()
    {
        while (true)
        {
            for(int i = 0; i < listOfenemy.Count; i++)
            {
                int hold = listOfenemy[i].look();
                
                if(hold == 3)
                {
                    System.Random rnd = new System.Random();
                    int h = rnd.Next(0, patrolLists.Count);

                    spawnParty(i,0,h);
                    yield return new WaitForSeconds(2);
                    spawnParty(i,1,h);
                    yield return new WaitForSeconds(2);
                    spawnParty(i,2,h);
                }
                yield return new WaitForSeconds(30);
            }

           yield return new WaitForSeconds(checkTime);
        }
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
