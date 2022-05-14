using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class imm7 : MonoBehaviour
{
    public float num;
    public float numtwo;
    public GameObject blue1;
    public GameObject blue2;
    public GameObject blue3;
    public GameObject blue4;
    public GameObject blue5;
    public GameObject blue6;
    public GameObject blue7;
    public GameObject blue8;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        numtwo = 4 - num;
        GetComponent<Text>().text = (((int)numtwo)).ToString();
        if(numtwo == 3)
        {
            blue1.SetActive(true);
            blue2.SetActive(true);

        }
        if (numtwo == 2)
        {
            blue3.SetActive(true);
            blue4.SetActive(true);

        }
        if (numtwo == 1)
        {
            blue5.SetActive(true);
            blue6.SetActive(true);

        }
        if (numtwo == 0)
        {
            blue7.SetActive(true);
            blue8.SetActive(true);

        }
    }
}
