using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float timeDelay;

    private bool isCoolDown;
    private bool inRange;
    private bool foundPot;
    private Collider target;
    private Collider pot;
    public Animator anim;

    public float forwardForce;
    public float upforce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void PlayerAttack()
    {
        anim.SetBool("attack", true);


        if (inRange)
        {
            Debug.Log(target.name + " " + "attacking");
            target.transform.gameObject.GetComponent<HealthOFEnemy>().PlayerDamage();
            target.transform.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce);
            target.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * upforce);

            inRange = false;
            StartCoroutine("cooldown");
        }

        if(foundPot)
        {
            pot.transform.gameObject.GetComponent<potBreak>().BreakPot();
            foundPot = false;
        }
    }

    IEnumerator cooldown()
    {
        isCoolDown = true;

        yield return new WaitForSeconds(timeDelay);

        isCoolDown = false;
        Debug.Log("off coolDown");
    }
    IEnumerator animcooldown()
    {
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("attack", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isCoolDown)
            {
                PlayerAttack();
            }
            else
            {
                Debug.Log("cooldown");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.tag == "Enemy")
        {
            Debug.Log("in range");
            inRange = true;
            target = other;
        }

        if (other.transform.gameObject.tag == "EnemyHealer")
        {
            //Debug.Log("in range");
            inRange = true;
            target = other;
        }

        if(other.transform.gameObject.tag == "Pot")
        {
            foundPot = true;
            pot = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "Enemy")
        {
            
            inRange = false;
            
        }

        if (other.transform.gameObject.tag == "EnemyHealer")
        {
            //Debug.Log("in range");
            inRange = false;
            
        }

        if (other.transform.gameObject.tag == "Pot")
        {
            foundPot = false;
            
        }
    }

    private void FixedUpdate()
    {
        if (anim.GetBool("attack") == true)
        {
            StartCoroutine("animcooldown");

        }
    }
}
