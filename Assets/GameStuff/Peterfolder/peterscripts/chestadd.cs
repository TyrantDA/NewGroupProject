using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestadd : MonoBehaviour
{
    public chestscript hold;
    public chestnumberopen hold2;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hold.close == true)
        {
            hold2.openr = 0;

        }
        else
        {
            hold2.openr = 1;

        }
    }
}
