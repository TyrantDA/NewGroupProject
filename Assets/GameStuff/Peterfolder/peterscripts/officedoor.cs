using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officedoor : MonoBehaviour
{
    public bool close = true;
    public bool go;
    public officedooropenre2 hold2;
    public officedooropenre hold1;

    // Start is called before the first frame update
    void Start()
    {
        go = false;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            go = true;


        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            go = false;


        }
    }
}