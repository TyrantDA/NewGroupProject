using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class imm8 : MonoBehaviour
{
    public scaryindex hold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = (hold.indx).ToString();
        if (hold.indx >= 150)
        {
            hold.gameObject.SetActive(false);
        }
    }
}
