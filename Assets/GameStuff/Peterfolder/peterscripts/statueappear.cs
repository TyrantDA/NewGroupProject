using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statueappear : MonoBehaviour
{
    public ItemListUI ui;
    public GameObject sta1;
    public GameObject sta2;
    public GameObject sta3;
    public GameObject sta4;
    public GameObject sta5;
    public GameObject sta6;
    public GameObject sta7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ui.checkGems("YellowGem") == true)
        {
            sta1.SetActive(true);
        }
        if (ui.checkGems("GreenGem") == true)
        {
            sta2.SetActive(true);

        }
        if (ui.checkGems("TurquoiseGem") == true)
        {
            sta3.SetActive(true);

        }
        if (ui.checkGems("BlueGem") == true)
        {
            sta4.SetActive(true);

        }
        if (ui.checkGems("RedGem") == true)
        {
            sta5.SetActive(true);

        }
        if (ui.checkGems("WhiteGem") == true)
        {
            sta6.SetActive(true);

        }
        if (ui.checkGems("PurpleGem") == true)
        {
            sta7.SetActive(true);

        }
    }
}
