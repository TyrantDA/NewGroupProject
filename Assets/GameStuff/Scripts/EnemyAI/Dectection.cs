using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dectection : MonoBehaviour
{
    // NPC has two dection system a retangle coming out of the front repiretion line of site
    public float mRaycastRadius;  // width of our line of sight (x-axis and y-axis)
    public float mTargetDetectionDistance;  // depth of our line of sight (z-axis)
    public Animator anim;

    // and a sphere around the NPC to detect thinks at close range 
    public float radiusDetect; //radius of detection around the NPC 

    public LayerMask detectLayers;

    public float combatRange;

    public EnemyAttack hitBox;
   
    public bool ranged;

    float walkingSpeed;
    public float runningSpeed;

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
    int damping =2;

    void Start()
    {
        pat = GetComponent<Patrol>();
        agent = GetComponent<NavMeshAgent>();
        seen = false;
        lastSeen = new Vector3(0f, 0f, 0f);
        currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
        foundSomething = false;
        walkingSpeed = agent.speed;
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
            anim.SetBool("walk", true);
            anim.SetBool("run", true);
            agent.speed = runningSpeed;
            agent.destination = lastSeen;
            hitRange = false;
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);

            if (ranged)
            {
                agent.velocity = Vector3.zero;
                agent.destination = transform.position;
                var lookPos = lastSeen - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
                hitRange = true;
                hitBox.goRanged(lastSeen);
            }
            else
            {
                agent.velocity = Vector3.zero;
                agent.destination = transform.position;
                var lookPos = lastSeen - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
                hitRange = true;
                hitBox.go();
            }
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
                                anim.SetBool("walk", false);
                                anim.SetBool("run", false);


                                transform.Rotate(Vector3.up * 10 * Time.deltaTime);
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
                            anim.SetBool("walk", false);
                            anim.SetBool("run", false);


                            transform.Rotate(Vector3.up * 10 * Time.deltaTime);
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
        anim.SetBool("run", false);
        agent.speed = walkingSpeed;
        CheckForTargetInLineOfSight();

        Debug.Log(agent.speed);
    }
}
