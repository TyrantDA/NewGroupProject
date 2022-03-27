using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectivescript : MonoBehaviour
{
    public Material hold3;
    public Material hold2;
    public bool completeone;
    public bool completetwo;
    public bool completethree;
    public bool completefour;
    public chestscript chesthold;
    public chestscript chesthold2;
    public chestscript chesthold3;
    public chestscript chesthold4;



    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material = hold2;

    }

    // Update is called once per frame
    void Update()
    {
        completeone = !chesthold.close;
        completetwo = !chesthold2.close;
        completethree = !chesthold3.close;
        completefour = !chesthold.close;
        if (completeone == true)
        {
            if (completetwo == true)
            {
                if (completethree == true)
                {
                    if (completefour == true)
                    {
                        this.GetComponent<Renderer>().material = hold3;

                    }
                }
            }
        }

    }
}
