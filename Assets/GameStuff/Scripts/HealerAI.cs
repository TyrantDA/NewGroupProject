using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealerAI : MonoBehaviour
{
    public float mRaycastRadius;  // width of our line of sight (x-axis and y-axis)
    public float mTargetDetectionDistance;  // depth of our line of sight (z-axis)
    public float radiusDetect; //radius of detection around the NPC 

    public LayerMask detectLayers;

    public float combatRange;

    private RaycastHit _mHitInfo;   // allocating memory for the raycasthit
    // to avoid Garbage
    private bool _bHasDetectedEnnemy = false;   // tracking whether the player
                                                // is detected to change color in gizmos
                                                // Start is called before the first frame update

    private bool foundSomething;

    Patrol pat;
    NavMeshAgent agent;
    Vector3 lastSeen;
    int damping = 2;
    bool seen;
    bool dectected;
    bool hitRange;

    float currentTime;
    float minTimeBetweenSpawns = 10;
    float maxTimeBetweenSpawns = 50;

    // Start is called before the first frame update
    void Start()
    {
        pat = GetComponent<Patrol>();
        agent = GetComponent<NavMeshAgent>();
        currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }

    float Lenth()
    {
        float answer = Vector3.Distance(transform.position, lastSeen);
        return answer;
    }

    void follow()
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
            var lookPos = lastSeen - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            hitRange = true;
        }
    }

    void dectect()
    {
        _bHasDetectedEnnemy = Physics.SphereCast(transform.position, mRaycastRadius, transform.forward, out _mHitInfo, mTargetDetectionDistance);
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
                        seen = true;
                        dectected = true;
                    }
                }
                else
                {
                    dectected = false;
                }
            }
            else
            {
                dectected = false;
            }
        }
        else
        {
            dectected = false;
        }


        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusDetect);

        for (int x = 0; x < hitColliders.Length; x++)
        {
            if (hitColliders[x].transform.CompareTag("Player"))
            {
                RaycastHit hitInfo;
                if (Physics.Linecast(transform.position, hitColliders[x].transform.position, out hitInfo, detectLayers))
                {
                    if (hitInfo.transform == hitColliders[x].transform)
                    {
                        //Debug.Log("Detected");
                        lastSeen = hitColliders[x].transform.position;
                        seen = true;
                        dectected = true;
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
        dectected = false;
        dectect();
        if(seen)
        {
            if (dectected)
            {
                follow();
            }
            else
            {
                Debug.Log("start searching");
                agent.destination = lastSeen;
                if (transform.position.x == lastSeen.x && transform.position.z == lastSeen.z)
                {
                    currentTime -= Time.deltaTime;

                    if (currentTime <= 0)
                    {
                        seen = false;
                        Debug.Log("stop search");
                        currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
                    }
                    else
                    {
                        transform.Rotate(Vector3.up * 4 * Time.deltaTime);
                    }

                }
            }
            
        }
        else
        {
            pat.PatrolRunning();
        }


    }
}
