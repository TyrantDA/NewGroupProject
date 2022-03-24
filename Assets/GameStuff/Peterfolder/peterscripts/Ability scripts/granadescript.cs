using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granadescript : MonoBehaviour
{
    public static granadescript x;

    public bool foundSomething = false;
    public float radiusDetect;
    public bool blowup = false;
    // Start is called before the first frame update
    void Start()
    {
        radiusDetect = 5;
        x = this;

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (collision.gameObject.CompareTag("floor"))
        {
            this.GetComponent<Rigidbody>().mass = 2000;
            blowup = true;
        }
    }
 
}
