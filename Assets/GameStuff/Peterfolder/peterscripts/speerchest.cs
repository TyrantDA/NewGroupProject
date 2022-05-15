using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speerchest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spreerstart");
    }
    IEnumerator spreerstart()
    {
        yield return new WaitForSeconds(8);
        this.gameObject.GetComponent<CapsuleCollider>().enabled = !this.gameObject.GetComponent<CapsuleCollider>().enabled;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
