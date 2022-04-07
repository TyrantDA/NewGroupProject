using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanchair : MonoBehaviour
{
    public bool startcleaning = false;
    // Start is called before the first frame update
    void Start()
    {
        startcleaning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startcleaning == true)
        {
            this.gameObject.tag = "clean";

        }
    }
}
