using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class potlink : MonoBehaviour
{
    public ptosnumber hold;
    public GameObject hold2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = (hold.remain).ToString();
        if (hold.remain == 0)
        {
            hold2.gameObject.SetActive(false);
        }

    }
}
