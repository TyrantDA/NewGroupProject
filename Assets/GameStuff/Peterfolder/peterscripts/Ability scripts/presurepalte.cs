using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presurepalte : MonoBehaviour
{
    public bool stoodon = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Delaythis");
        }
    }
    IEnumerator Delaythis()
    {
        yield return new WaitForSeconds(2);
        stoodon = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
