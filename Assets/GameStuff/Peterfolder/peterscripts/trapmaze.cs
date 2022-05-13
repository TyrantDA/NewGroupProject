using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapmaze : MonoBehaviour
{
    public fixspikes hold1;
    public fixspikes hold2;
    public fixspikes hold3;
    public fixspikes hold4;
    public fixspikes hold5;
    public fixspikes hold6;
    public fixspikes hold7;
    public fixspikes hold8;
    public fixspikes hold9;
    public fixspikes hold10;
    public fixspikes hold11;
    public fixspikes hold12;
    public fixspikes hold13;
    public fixspikes hold14;

    public bool yes1;
    public bool yes2;
    public bool yes3;
    public bool yes4;
    public bool yes5;
    public bool yes6;
    public bool yes7;
    public bool yes8;
    public bool yes9;
    public bool yes10;
    public bool yes11;
    public bool yes12;
    public bool yes13;
    public bool yes14;
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
        yes9 = false;
        yes10 = false;
        yes11 = false;
        yes12 = false;
        yes13 = false;
        yes14 = false;
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
        if (hold6.fix == true)
        {
            if (yes6 == false)
            {
                yes6 = true;
                left = left + 1;
            }
        }
        if (hold7.fix == true)
        {
            if (yes7 == false)
            {
                yes7 = true;
                left = left + 1;
            }
        }
        if (hold8.fix == true)
        {
            if (yes8 == false)
            {
                yes8 = true;
                left = left + 1;
            }
        }
        if (hold9.fix == true)
        {
            if (yes9 == false)
            {
                yes9 = true;
                left = left + 1;
            }
        }
        if (hold10.fix == true)
        {
            if (yes10 == false)
            {
                yes10 = true;
                left = left + 1;
            }
        }
        if (hold11.fix == true)
        {
            if (yes11 == false)
            {
                yes11 = true;
                left = left + 1;
            }
        }
        if (hold12.fix == true)
        {
            if (yes12 == false)
            {
                yes12 = true;
                left = left + 1;
            }
        }
        if (hold13.fix == true)
        {
            if (yes13 == false)
            {
                yes13 = true;
                left = left + 1;
            }
        }
        if (hold14.fix == true)
        {
            if (yes14 == false)
            {
                yes14 = true;
                left = left + 1;
            }
        }

    }

}
