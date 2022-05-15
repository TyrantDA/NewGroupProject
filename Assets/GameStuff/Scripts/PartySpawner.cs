using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySpawner : MonoBehaviour
{
    [SerializeField] List<Party> listOfenemy = new List<Party>();
    [SerializeField] List<PatrolList> patrolLists = new List<PatrolList>();

    public GameObject spawnPoint1;

    public int checkTime;

    List<int> patrolHold = new List<int>();

    int spawntime = 0;
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

    int StartPatrol()
    {
        patrolHold = new List<int>();

        System.Random rnd = new System.Random();
        int h = rnd.Next(0, patrolLists.Count);

        patrolHold.Add(h);

        return h;
    }

    int nextPatrol()
    {
        bool checking = true;
        
        int h = 0;
        while(checking)
        {
            int same = 0;
            System.Random rnd = new System.Random();
            h = rnd.Next(0, patrolLists.Count);

            for(int i = 0; i < patrolHold.Count; i++)
            {
                if(patrolHold[i] == h)
                {
                    same++;
                }
            }

            if(same < patrolHold.Count)
            {
                checking = false;
            }

        }

        return h;  
    }
    IEnumerator Check()
    {
        
        while (true)
        {
            int h = StartPatrol();
            for (int i = 0; i < listOfenemy.Count; i++)
            {
                
                int hold = listOfenemy[i].look();
                
                if(hold == 3)
                {
                    

                    spawnParty(i,0,h);
                    yield return new WaitForSeconds(2);
                    spawnParty(i,1,h);
                    yield return new WaitForSeconds(2);
                    spawnParty(i,2,h);

                    if(spawntime > 0)
                    {
                        int achieve = PlayerPrefs.GetInt("triple Kill", 0);
                        if(achieve == 0)
                        {
                            PlayerPrefs.SetInt("triple Kill", 1);
                        }
                    }
                }
                yield return new WaitForSeconds(30);
                h = nextPatrol();
            }

           yield return new WaitForSeconds(checkTime);
           spawntime++;
        }
        
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
