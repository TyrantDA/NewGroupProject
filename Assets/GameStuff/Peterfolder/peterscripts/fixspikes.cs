using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixspikes : MonoBehaviour
{
    public bool fix;
    public bool running;

    public int count;
    // Start is called before the first frame update
    void Start()
    {
        running = false;
        transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = false;

    }
    IEnumerator delay()
    {
        running = true;
        yield return new WaitForSeconds(count);
        transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = false;

        Debug.Log("ff");
        running = false;


    }
    void Update()
    {
        if (fix == true)
        {
            if(running == true)
            {
                StopCoroutine("delay");
                running = false;

            }
            StartCoroutine("delay");
            transform.GetChild(1).gameObject.GetComponent<Animation>().enabled = true;

        }
    }

        //Check to see if the tag on the collider is equal to Enemy

    
}
