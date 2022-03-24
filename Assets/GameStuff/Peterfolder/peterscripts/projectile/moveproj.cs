using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveproj : MonoBehaviour
{ 
    Rigidbody rb;
    public float speed;

    void Start()
    {
        speed = throwingproj.x.i;
        rb = GetComponent<Rigidbody>();
        rb.AddForce((throwingproj.x.forward * speed), ForceMode.Impulse);
        rb.AddForce(new Vector3(0, 5 + speed *1.25f, 0), ForceMode.Impulse);

    }

    void FixedUpdate()
    {
    }
}

