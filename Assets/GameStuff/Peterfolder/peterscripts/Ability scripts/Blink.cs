using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            transform.position = transform.position + transform.forward * 7;
        }
        if (Input.GetKeyDown("g"))
        {
            transform.position = transform.position - transform.forward * 7;
        }

    }
}
