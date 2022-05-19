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

    public float followRange;
    public float combatRange;
    public Animator anim;

    public EnemyAttack hitBox;

    float walkingSpeed;
    public float RunningSpeed;
    public AudioSource walking;
    bool ifWalkPlaying = false;

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
    bool seenPartyMember;
    bool dectectedPartyMember;
    bool seenPlayer;
    bool dectectedPlayer;
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
        walkingSpeed = agent.speed;
    }

    float Lenth()
    {
        float answer = Vector3.Distance(transform.position, lastSeen);
        return answer;
    }

    void follow()
    {
        float hold = Lenth();
        if (hold > followRange)
        {
            anim.SetBool("walk", true);
            anim.SetBool("run", true);
            agent.speed = RunningSpeed;
            agent.destination = lastSeen;
        }
        else
        {
            anim.SetBool("walk", false);

            agent.velocity = Vector3.zero;
            agent.destination = transform.position;

            var lookPos = lastSeen - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        }
    }

    void engage()
    {
        float hold = Lenth();
        if (hold > combatRange)
        {
            anim.SetBool("walk", true);
            anim.SetBool("run", true);
            agent.speed = RunningSpeed;
            agent.destination = lastSeen;


            hitRange = false;
        }
        else
        {
            anim.SetBool("walk", false);

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

    void dectect()
    {
        _bHasDetectedEnnemy = Physics.SphereCast(transform.position, mRaycastRadius, transform.forward, out _mHitInfo, mTargetDetectionDistance);
        if (_bHasDetectedEnnemy)
        {
            if (_mHitInfo.transform.CompareTag("Enemy"))
            {
                RaycastHit hitInfo;
                if (Physics.Linecast(transform.position, _mHitInfo.transform.position, out hitInfo, detectLayers))
                {
                    if (hitInfo.transform == _mHitInfo.transform)
                    {
                        //Debug.Log("Detected Player");
                        lastSeen = _mHitInfo.transform.position;
                        seenPartyMember = true;
                        dectectedPartyMember = true;
                        pat.SetPatrolList(_mHitInfo.transform.gameObject.GetComponent<Patrol>().GetPatrolList(), _mHitInfo.transform.gameObject.GetComponent<Patrol>().GetPatrolWait());
                        pat.setCurrentMoveTo(_mHitInfo.transform.gameObject.GetComponent<Patrol>().getCurrentMoveTo());
                    }
                }
                else
                {
                    dectectedPartyMember = false;
                }
            }
            else
            {
                dectectedPartyMember = false;
            }
        }
        else
        {
            dectectedPartyMember = false;
        }


        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusDetect);

        for (int x = 0; x < hitColliders.Length; x++)
        {
            if (hitColliders[x].transform.CompareTag("Enemy"))
            {
                RaycastHit hitInfo;
                if (Physics.Linecast(transform.position, hitColliders[x].transform.position, out hitInfo, detectLayers))
                {
                    if (hitInfo.transform == hitColliders[x].transform)
                    {
                        //Debug.Log("Detected");
                        lastSeen = hitColliders[x].transform.position;
                        seenPartyMember = true;
                        dectectedPartyMember = true;
                        pat.SetPatrolList(hitColliders[x].transform.gameObject.GetComponent<Patrol>().GetPatrolList(), hitColliders[x].transform.gameObject.GetComponent<Patrol>().GetPatrolWait());
                        pat.setCurrentMoveTo(hitColliders[x].transform.gameObject.GetComponent<Patrol>().getCurrentMoveTo());


                    }
                }
                
            }

        }

      

    }

    void DectectPlayer()
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
                        seenPlayer = true;
                        dectectedPlayer = true;
                    }
                }
                else
                {
                    dectectedPlayer = false;
                }
            }
            else
            {
                dectectedPlayer = false;
            }
        }
        else
        {
            dectectedPlayer = false;
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
                        seenPlayer = true;
                        dectectedPlayer = true;
                    }
                }

            }

        }
    }

    void Search()
    {
       // Debug.Log("start searching");
        agent.destination = lastSeen;

        if (transform.position.x == lastSeen.x && transform.position.z == lastSeen.z)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                seenPartyMember = false;
                //Debug.Log("stop search");
                currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            }
            else
            {
                anim.SetBool("walk", false);

                transform.Rotate(Vector3.up * 10 * Time.deltaTime);
            }

        }
    }

    void SearchPlayer()
    {
        Debug.Log("start searching");
        agent.destination = lastSeen;
        if (transform.position.x == lastSeen.x && transform.position.z == lastSeen.z)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                seenPlayer = false;
                Debug.Log("stop search");
                currentTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            }
            else
            {
                anim.SetBool("walk", false);

                transform.Rotate(Vector3.up * 10 * Time.deltaTime);
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

    //Update is called once per frame
    void Update()
    {
        anim.SetBool("run", false);
        agent.speed = walkingSpeed;
        dectectedPartyMember = false;
        dectect();
        if(seenPartyMember)
        {
            if (dectectedPartyMember)
            {
                follow();
            }
            else
            {
                Search();
                dectectedPlayer = false;
                DectectPlayer();
                if (seenPlayer)
                {
                    if (dectectedPlayer)
                    {
                        engage();
                    }
                    else
                    {
                        SearchPlayer();
                    }
                }
            }
            
        }
        else
        {
            dectectedPlayer = false;
            DectectPlayer();
            if(seenPlayer)
            {
                if(dectectedPlayer)
                {
                    engage();
                }
                else
                {
                    SearchPlayer();
                }
            }
            else
            {
                pat.PatrolRunning();
            }
            
        }

        if (agent.velocity.x != 0 || agent.velocity.z != 0)
        {
            if (!ifWalkPlaying)
            {
                Debug.Log("play walking");
                walking.Play();
                ifWalkPlaying = true;
            }
        }
        else
        {
            if (ifWalkPlaying)
            {
                walking.Pause();
                ifWalkPlaying = false;
            }
        }
        

    }
}
