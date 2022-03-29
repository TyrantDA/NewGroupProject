using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempobjctives : MonoBehaviour
{
    public GameObject hold;
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

    }

    // Update is called once per frame
    void Update()
    {
        completeone = !chesthold.close;
        completetwo = !chesthold2.close;
        completethree = !chesthold3.close;
        completefour = !chesthold4.close;
        if (completeone == true)
        {
            if (completetwo == true)
            {
                if (completethree == true)
                {
                    if (completefour == true)
                    {
                        hold.SetActive(true);

                    }
                    else
                    {
                        hold.SetActive(false);

                    }
                }
                else
                {
                    hold.SetActive(false);

                }
            }
            else
            {
                hold.SetActive(false);

            }
        }
        else
        {
            hold.SetActive(false);

        }
    }


    
}
