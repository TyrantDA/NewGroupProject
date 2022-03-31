using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dectection : MonoBehaviour
{
    // NPC has two dection system a retangle coming out of the front repiretion line of site
    public float mRaycastRadius;  // width of our line of sight (x-axis and y-axis)
    public float mTargetDetectionDistance;  // depth of our line of sight (z-axis)

    // and a sphere around the NPC to detect thinks at close range 
    public float radiusDetect; //radius of detection around the NPC 

    public LayerMask detectLayers;

    public float combatRange;

    public EnemyAttack hitBox;

    float currentTime;
    float minTimeBetweenSpawns = 10;
    float maxTimeBetweenSpawns = 50;


    private RaycastHit _mHitInfo;   // allocating memory for the raycasthit
    // to avoid Garbage
    private bool _bHasDetectedEnnemy = false;   // tracking whether the player
                                                // is detected to change color in gizmos
                                                // Start is called before the first frame update

    private bool foundSomething;

    Patrol pat;
    NavMeshAgent agent;
    bool seen;
    Vector3 lastSeen;
    bool hitRange;
    

    void Start()
    {
        pat = GetComponent<Patrol>();
        agent = GetComponent<NavMeshAgent>();
        seen = false;
        lastSeen = new Vector3(0f, 0f, 0f);
        currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
        foundSomething = false;
    }

    float Lenth()
    {
        float answer = Vector3.Distance(transform.position, lastSeen);
        return answer;
    }

    void engage()
    {
        float hold = Lenth();
        if (hold > combatRange)
        {
            agent.destination = lastSeen;
            hitRange = false;
        }
        else
        {
            agent.velocity = Vector3.zero;
            agent.destination = transform.position;
            hitRange = true;
            hitBox.go();
        }
    }

    public void CheckForTargetInLineOfSight()
    {
        _bHasDetectedEnnemy = Physics.SphereCast(transform.position, mRaycastRadius, transform.forward, out _mHitInfo, mTargetDetectionDistance);


        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusDetect);
        int hold = 0;

        for (int x = 0; x < hitColliders.Length; x++)
        {
            if (hitColliders[x].transform.CompareTag("Player"))
            {
                foundSomething = true;
                hold = x;
                //Debug.Log("have It");
            }

        }
        if (foundSomething)
        {
            RaycastHit hitInfo;
            if (Physics.Linecast(transform.position, hitColliders[hold].transform.position, out hitInfo, detectLayers))
            {
                if (hitInfo.transform == hitColliders[hold].transform)
                {
                    //Debug.Log("Detected");
                    lastSeen = hitColliders[hold].transform.position;
                    engage();

                    seen = true;
                    _bHasDetectedEnnemy = false;
                }
            }
            foundSomething = false;
        }



        if (_bHasDetectedEnnemy)
        {
            if (_mHitInfo.transform.CompareTag("Player"))
            {
                RaycastHit hitInfo;
                if (Physics.Linecast(transform.position, _mHitInfo.transform.position, out hitInfo, detectLayers))
                {
                    if (hitInfo.transform == _mHitInfo.transform)
                    {
                        //Debug.Log("Detected Player");
                        lastSeen = _mHitInfo.transform.position;
                        engage();

                        seen = true;
                    }
                }
            }
            else
            {
                if (!seen)
                {
                    
                    if(!foundSomething)
                    {

                        //Debug.Log("start Patrolling");
                        pat.PatrolRunning();
                    }
                }
                else
                {


                    if (!hitRange)
                    {
                        //Debug.Log("start searching");
                        agent.destination = lastSeen;
                        if (transform.position.x == lastSeen.x && transform.position.z == lastSeen.z)
                        {
                            currentTime -= Time.deltaTime;

                            if (currentTime <= 0)
                            {
                                seen = false;
                                //Debug.Log("stop search");
                                currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
                            }
                            else
                            {
                                transform.Rotate(Vector3.up * 4 * Time.deltaTime);
                            }

                        }
                    }
                }
            }

        }
        else
        {
            if (!seen)
            {
                //Debug.Log("start Patrolling");
                pat.PatrolRunning();
            }
            else
            {
                if (!hitRange)
                {
                    //Debug.Log("start searching");
                    agent.destination = lastSeen;
                    if (transform.position.x == lastSeen.x && transform.position.z == lastSeen.z)
                    {
                        currentTime -= Time.deltaTime;

                        if (currentTime <= 0)
                        {
                            seen = false;
                            //Debug.Log("stop search");
                            currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
                        }
                        else
                        {
                            transform.Rotate(Vector3.up * 4 * Time.deltaTime);
                        }
                    }
                }
            }

        }



        }

    private void OnDrawGizmos()
    {
        if (_bHasDetectedEnnemy)
        {
            if (_mHitInfo.transform.CompareTag("Player"))
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.yellow; 
            }
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawCube(new Vector3(0f, 0f, mTargetDetectionDistance / 2f), new Vector3(mRaycastRadius, mRaycastRadius, mTargetDetectionDistance));
    }


    // Update is called once per frame
    void Update()
    {
        //CheckForTargetInLineOfSight();
    }

    private void FixedUpdate()
    {
        CheckForTargetInLineOfSight();
    }
}
