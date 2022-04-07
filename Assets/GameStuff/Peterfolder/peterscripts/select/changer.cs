using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changer : MonoBehaviour
{
    public identified hold;
    public bool change;
    // Start is called before the first frame update
    void Start()
    {
        change = false;
    }

    void Update()
    {
        change = hold.spotted;


    }
}
