using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class imm7 : MonoBehaviour
{
    public float num;
    public float numtwo;
    public bool left;
    public GameObject blue1;
    public GameObject blue2;
    public GameObject blue3;
    public GameObject blue4;
    public GameObject blue5;
    public GameObject blue6;
    public GameObject blue7;
    public GameObject blue8;
    public GameObject hold;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        numtwo = 4 - num;

        if (numtwo == 0)
        {
            hold.gameObject.SetActive(false);
        }
        GetComponent<Text>().text = ((numtwo)).ToString();
        if(numtwo == 3 || numtwo == 3.5)
        {
            if (numtwo -(int)numtwo == 0)
            {
                blue1.SetActive(true);
                blue2.SetActive(true);

            }
            else
            {
                if (left == true)
                {
                    blue1.SetActive(true);

                }
                else
                {
                    blue2.SetActive(true);

                }
            }

        }
        if (numtwo == 2 || numtwo == 2.5)
        {
            if (numtwo - (int)numtwo == 0)
            {
                blue1.SetActive(true);
                blue2.SetActive(true);
                blue3.SetActive(true);
                blue4.SetActive(true);

            }
            else
            {
                if (left == true)
                {
                    blue1.SetActive(true);
                    blue2.SetActive(true);
                    blue3.SetActive(true);

                }
                else
                {
                    blue1.SetActive(true);
                    blue2.SetActive(true);
                    blue4.SetActive(true);

                }
            }

        }
        if (numtwo == 1 || numtwo == 1.5)
        {
            if (numtwo - (int)numtwo == 0)
            {
                blue1.SetActive(true);
                blue2.SetActive(true);
                blue3.SetActive(true);
                blue4.SetActive(true);
                blue5.SetActive(true);
                blue6.SetActive(true);

            }
            else
            {
                if (left == true)
                {
                    blue1.SetActive(true);
                    blue2.SetActive(true);
                    blue3.SetActive(true);
                    blue4.SetActive(true);
                    blue5.SetActive(true);

                }
                else
                {
                    blue1.SetActive(true);
                    blue2.SetActive(true);
                    blue3.SetActive(true);
                    blue4.SetActive(true);
                    blue6.SetActive(true);

                }
            }


        }
        if (numtwo == 0 || numtwo == 0.5)
        {
            if (numtwo - (int)numtwo == 0)
            {
                blue1.SetActive(true);
                blue2.SetActive(true);
                blue3.SetActive(true);
                blue4.SetActive(true);
                blue5.SetActive(true);
                blue6.SetActive(true);
                blue7.SetActive(true);
                blue8.SetActive(true);
            }
            else
            {
                if (left == true)
                {
                    blue1.SetActive(true);
                    blue2.SetActive(true);
                    blue3.SetActive(true);
                    blue4.SetActive(true);
                    blue5.SetActive(true);
                    blue6.SetActive(true);
                    blue7.SetActive(true);

                }
                else
                {
                    blue1.SetActive(true);
                    blue2.SetActive(true);
                    blue3.SetActive(true);
                    blue4.SetActive(true);
                    blue5.SetActive(true);
                    blue6.SetActive(true);
                    blue8.SetActive(true);

                }
            }


        }
    }
}
