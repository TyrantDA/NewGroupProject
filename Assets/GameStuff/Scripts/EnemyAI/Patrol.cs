using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{

    public List<GameObject> patrolList; //list of empty object used a point to patrol between
    public List<int> patrolWait;
    public GameObject Patroller; //  game object that will be the enemy AI
    public float speed; // not used

    int currentMovingTo;
    int holdWait;
    [SerializeField] GameObject target;
    NavMeshAgent agent;
    bool patrolling;
    bool delayWait;

    // Start is called before the first frame update
    void Start()
    {
        target = closest(Patroller);
        Debug.Log(target.name);
        agent = GetComponent<NavMeshAgent>();
        patrolling = false;
        delayWait = false;
    }

    public void SetPatrolList(List<GameObject> hold, List<int> hold2)
    {
        patrolList = hold;
        patrolWait = hold2;
    }

    public void setPatrolling(bool set)
    {
        patrolling = set;
    }
    
    // work out the distance between two game objects 
    float Lenth(GameObject p, GameObject pat)
    {
        float answer = Vector3.Distance(p.transform.position, pat.transform.position);
        return answer;
    }

    // find the closest patrol point to the enemy AI
    GameObject closest(GameObject player)
    {
        int key = 0;
        float comareHold = 0;
        float comare = 0;

        for (int x = 0; x < patrolList.Count; x++)
        {
            comare = Lenth(player, patrolList[x]);
            if(comareHold > comare)
            {
                comareHold = comare;
                key = x;
            }
            else if(comareHold == comare)
            {
                comareHold = comare;
                key = x;
            }
              
        }

        GameObject hold = patrolList[key];
        currentMovingTo = key;
        return hold;
    }

    // find the next patrol point to move two
    GameObject nextTarget()
    {

        holdWait = currentMovingTo;
        StartCoroutine("delay");
        currentMovingTo++;

        if(currentMovingTo >= patrolList.Count)
        {
            currentMovingTo = 0;
        }

        return patrolList[currentMovingTo];
    }

    IEnumerator delay()
    {
        delayWait = true;
        //Debug.Log("wait for " + patrolWait[holdWait]);
        yield return new WaitForSeconds(patrolWait[holdWait]);

        delayWait = false;
    }

        // run when patrolling. set the position to go to and check if they have reach in if so the next target function is run
        public void PatrolRunning()
    {
        if (!delayWait)
        {
            agent.destination = target.transform.position;
            
            //float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

            //Debug.Log("patrol pos: " + transform.position.x + " : " + transform.position.z + " | point pos : "+ target.transform.position.x + " : " + target.transform.position.z);

            if (transform.position.x == target.transform.position.x && transform.position.z == target.transform.position.z)
            {
                target = nextTarget();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (patrolling)
        //{
        //    agent.destination = target.transform.position;
        //    //float step = speed * Time.deltaTime;
        //    //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        //    //Debug.Log("patrol pos: " + transform.position.x + " : " + transform.position.z + " | point pos : "+ target.transform.position.x + " : " + target.transform.position.z);

        //    if (transform.position.x == target.transform.position.x && transform.position.z == target.transform.position.z)
        //    {
        //        target = nextTarget();
        //    }
        //}
          
    }
}
