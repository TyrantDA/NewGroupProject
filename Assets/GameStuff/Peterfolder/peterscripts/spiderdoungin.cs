using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderdoungin : MonoBehaviour
{
    public bookfixer hold1;
    public doorfix hold2;
    public doorfix2 hold3;
    public doorfix3 hold4;
    public doorfix4 hold5;
    public fixdoors5 hold6;
    public speerwall hold7;
    public fixcage hold8;
    public bool yes1;
    public bool yes2;
    public bool yes3;
    public bool yes4;
    public bool yes5;
    public bool yes6;
    public bool yes7;
    public bool yes8;
    public int left;

    void Start()
    {
        left = 0;
        yes1 = false;
        yes2 = false;
        yes3 = false;
        yes4 = false;
        yes5 = false;
        yes6 = false;
        yes7 = false;
        yes8 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hold1.book == 13)
        {
            if(yes1 == false)
            {
                yes1 = true;
                left = left + 1;
            }
        }
        if (hold2.done == true)
        {
            if (yes2 == false)
            {
                yes2 = true;
                left = left + 1;
            }
        }
        if (hold3.done == true)
        {
            if (yes3 == false)
            {
                yes3 = true;
                left = left + 1;
            }
        }
        if (hold4.done == true)
        {
            if (yes4 == false)
            {
                yes4 = true;
                left = left + 1;
            }
        }
        if (hold5.done == true)
        {
            if (yes5 == false)
            {
                yes5 = true;
                left = left + 1;
            }
        }
        if (hold6.done == true)
        {
            if (yes6 == false)
            {
                yes6 = true;
                left = left + 1;
            }
        }
        if (hold7.done == true)
        {
            if (yes7 == false)
            {
                yes7 = true;
                left = left + 1;
            }
        }
        if (hold8.done == true)
        {
            if (yes8 == false)
            {
                yes8 = true;
                left = left + 1;
            }
        }

    }

}
