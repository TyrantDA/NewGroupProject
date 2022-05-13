using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float timeDelay;

    private bool isCoolDown;
    private bool inRange;
    private bool foundPot;
    private bool foundGPot;

    private Collider target;
    private Collider pot;
    private Collider Gpot;

    public Animator anim;
    public HealthOfPlayer hop;
    public float forwardForce;
    public float upforce;
    [SerializeField] bool damagePotionOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void damageBoostSet(bool hold)
    {
        damagePotionOn = hold;
    }

    public bool damageBoosteGet()
    {
        return damagePotionOn;
    }

    void PlayerAttack()
    {
        anim.SetBool("attack", true);


        if (inRange)
        {
            Debug.Log(target.name + " " + "attacking");
            if (!damagePotionOn)
            {
                target.transform.gameObject.GetComponent<HealthOFEnemy>().PlayerDamage();
            }
            else
            {
                target.transform.gameObject.GetComponent<HealthOFEnemy>().DamagePlayerBoosted();
            }
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
        if (foundGPot)
        {
            hop.potdam();
            Gpot.transform.gameObject.GetComponent<potBreak>().BreakPot();
            foundGPot = false;
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
        if (other.transform.gameObject.tag == "GPot")
        {
            foundGPot = true;
            Gpot = other;
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
        if (other.transform.gameObject.tag == "GPot")
        {
            foundGPot = false;

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
