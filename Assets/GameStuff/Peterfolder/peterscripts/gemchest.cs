using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemchest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Gemstart");
    }
    IEnumerator Gemstart()
    {
        yield return new WaitForSeconds(6);
        this.gameObject.GetComponent<CapsuleCollider>().enabled = !this.gameObject.GetComponent<CapsuleCollider>().enabled;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
