using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathplayer : MonoBehaviour
{
    public bool acive = true;
    public bool stopped = false;
    public float heath;
    public Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();

        heath = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if (acive != true)
        {

            if (stopped != true)
            {
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                GetComponent<TopDownCharacterMover>().enabled = !GetComponent<TopDownCharacterMover>().enabled;

                RB.velocity = Vector3.zero;
                RB.angularVelocity = Vector3.zero;
                RB.Sleep();
                stopped = true;
                Debug.Log("printthis");
                StartCoroutine("Delaythis");


            }
        }
        if (acive == true)
        {
            if (stopped == true)
            {
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                GetComponent<TopDownCharacterMover>().enabled = !GetComponent<TopDownCharacterMover>().enabled;

                RB.velocity = Vector3.zero;
                RB.angularVelocity = Vector3.zero;
                RB.Sleep();
                Debug.Log("printthis");

                stopped = false;

            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (collision.gameObject.CompareTag("stun"))
        {
            acive = false;
        }
    }
    IEnumerator Delaythis()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("printthis");

        acive = true;


    }
}
