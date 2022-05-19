using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeDelay;
    public GameObject spawnPoint;
    public GameObject Spell;
    public Animator anim;

    private bool isCoolDown;
    private bool inRange;
    private Collider target;

    public float forwardForce;
    public float upforce;
    public AudioSource hitNoise;
    public AudioSource spellNoise;
    public bool hasSword;
    // Start is called before the first frame update
    void Start()
    {

    }


    void PlayerAttack()
    {

    //    anim.SetBool("attack", true);

        if (inRange)
        {
            Debug.Log("hit");
            target.transform.gameObject.GetComponent<HealthOfPlayer>().DamagePlayer();
            if (hasSword)
            {
                hitNoise.Play();
            }
            target.transform.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce);
            target.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * upforce);
            inRange = false;
            StartCoroutine("cooldown");
        }
    }

    IEnumerator cooldown()
    {
        isCoolDown = true;

        yield return new WaitForSeconds(timeDelay);

        isCoolDown = false;
        //Debug.Log("off coolDown");
    }


    // Update is called once per frame
    public void go()
    {
            if (!isCoolDown)
            {
            anim.SetBool("attack", true);

            PlayerAttack();
            }
            else
            {
                Debug.Log("cooldown");
            }
    }

    public void goRanged(Vector3 target)
    {

        if (!isCoolDown)
        {

            anim.SetBool("attack", true);

            GameObject hold = Instantiate(Spell, spawnPoint.transform.position, transform.rotation);
            spellNoise.Play();
            hold.GetComponent<spell>().target = target;
            StartCoroutine("cooldown");
        }
        else
        {
            Debug.Log("cooldown");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            //Debug.Log("in range");
            inRange = true;
            target = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            //Debug.Log("in range");
            inRange = false;
            
        }
    }

    private void FixedUpdate()
    {
        if (anim.GetBool("attack") == true)
        {
            anim.SetBool("attack", false);

        }
    }
}
