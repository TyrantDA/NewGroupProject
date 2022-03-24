using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eheathndeath : MonoBehaviour
{
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

    }
    private void OnCollisionEnter(Collision collision)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (collision.gameObject.CompareTag("kill"))
        {
            heath = heath - 100;
        }
    }
}
