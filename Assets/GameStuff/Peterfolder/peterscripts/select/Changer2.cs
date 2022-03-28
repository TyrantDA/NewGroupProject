using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer2 : MonoBehaviour
{
    public identified hold;
    public identified hold2;

    public bool change;
    // Start is called before the first frame update
    void Start()
    {
        change = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hold.spotted == true)
        {
            change = true;
        }
        if (hold2.spotted == true)
        {
            change = true;
        }

    }
}