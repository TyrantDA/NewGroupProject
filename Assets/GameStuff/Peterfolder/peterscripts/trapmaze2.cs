using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapmaze2 : MonoBehaviour
{
    public fixspikes hold1;
    public fixspikes hold2;
    public fixspikes hold3;
    public fixspikes hold4;
    public fixspikes hold5;

    public bool yes1;
    public bool yes2;
    public bool yes3;
    public bool yes4;
    public bool yes5;

    public int left;

    void Start()
    {
        left = 0;
        yes1 = false;
        yes2 = false;
        yes3 = false;
        yes4 = false;
        yes5 = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (hold1.fix == true)
        {
            if (yes1 == false)
            {
                yes1 = true;
                left = left + 1;
            }
        }
        if (hold2.fix == true)
        {
            if (yes2 == false)
            {
                yes2 = true;
                left = left + 1;
            }
        }
        if (hold3.fix == true)
        {
            if (yes3 == false)
            {
                yes3 = true;
                left = left + 1;
            }
        }
        if (hold4.fix == true)
        {
            if (yes4 == false)
            {
                yes4 = true;
                left = left + 1;
            }
        }
        if (hold5.fix == true)
        {
            if (yes5 == false)
            {
                yes5 = true;
                left = left + 1;
            }
        }
    }

}
