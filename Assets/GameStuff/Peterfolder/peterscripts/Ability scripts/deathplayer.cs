using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathplayer : MonoBehaviour
{
    public bool acive = true;
    public bool stopped = false;
    public float heath;
    // Start is called before the first frame update
    void Start()
    {
        heath = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (heath <= 0)
        {
            Destroy(this.gameObject);
        }
        if (acive != true)
        {

            if (stopped != true)
            {
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                stopped = true;

                StartCoroutine("Delaythis");


            }
        }
        if (acive == true)
        {
            if (stopped == true)
            {
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                stopped = false;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (collision.gameObject.CompareTag("kill"))
        {
            heath = heath - 20;
        }
        if (collision.gameObject.CompareTag("stun"))
        {
            acive = false;
        }
    }
    IEnumerator Delaythis()
    {
        yield return new WaitForSeconds(5);
        acive = true;


    }
}
