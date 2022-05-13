using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imm2 : MonoBehaviour
{ 
    public trapmaze2 hold;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = (5 - hold.left).ToString();

    }
}
