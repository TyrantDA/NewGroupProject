using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetballs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(this.gameObject);
        }
    }
}
