using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cc2 : MonoBehaviour
{
    public Material hold3;

    public Material hold2;
    public Changer2 hold;
    public bool changed;

    // Start is called before the first frame update
    void Start()
    {
        changed = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        changed = hold.change;
        if (changed == true)
        {
            this.GetComponent<Renderer>().material = hold2;
        }
        if (changed != true)
        {
            this.GetComponent<Renderer>().material = hold3;
        }

    }
}
