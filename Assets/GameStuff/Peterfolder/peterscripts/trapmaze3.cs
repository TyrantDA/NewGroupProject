using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapmaze3 : MonoBehaviour
{
    public arrowfix hold1;
    public arrowfix hold2;
    public arrowfix hold3;
    public arrowfix hold4;
    public arrowfix hold5;
    public arrowfix hold6;
    public arrowfix hold7;
    public arrowfix hold8;
    public arrowfix hold9;
    public arrowfix hold10;
    public arrowfix hold11;
    public arrowfix hold12;
    public arrowfix hold13;
    public arrowfix hold14;


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
        if (hold1.fixe == true)
        {
            if (yes1 == false)
            {
                yes1 = true;
                left = left + 1;
            }
        }
        if (hold2.fixe == true)
        {
            if (yes2 == false)
            {
                yes2 = true;
                left = left + 1;
            }
        }
        if (hold3.fixe == true)
        {
            if (yes3 == false)
            {
                yes3 = true;
                left = left + 1;
            }
        }
        if (hold4.fixe == true)
        {
            if (yes4 == false)
            {
                yes4 = true;
                left = left + 1;
            }
        }
        if (hold5.fixe == true)
        {
            if (yes5 == false)
            {
                yes5 = true;
                left = left + 1;
            }
        }
        if (hold6.fixe == true)
        {
            if (yes6 == false)
            {
                yes6 = true;
                left = left + 1;
            }
        }
        if (hold7.fixe == true)
        {
            if (yes7 == false)
            {
                yes7 = true;
                left = left + 1;
            }
        }
        if (hold8.fixe == true)
        {
            if (yes8 == false)
            {
                yes8 = true;
                left = left + 1;
            }
        }
        if (hold9.fixe == true)
        {
            if (yes9 == false)
            {
                yes9 = true;
                left = left + 1;
            }
        }
        if (hold10.fixe == true)
        {
            if (yes10 == false)
            {
                yes10 = true;
                left = left + 1;
            }
        }
        if (hold11.fixe == true)
        {
            if (yes11 == false)
            {
                yes11 = true;
                left = left + 1;
            }
        }
        if (hold12.fixe == true)
        {
            if (yes12 == false)
            {
                yes12 = true;
                left = left + 1;
            }
        }
        if (hold13.fixe == true)
        {
            if (yes13 == false)
            {
                yes13 = true;
                left = left + 1;
            }
        }
        if (hold14.fixe == true)
        {
            if (yes14 == false)
            {
                yes14 = true;
                left = left + 1;
            }
        }

    }

}