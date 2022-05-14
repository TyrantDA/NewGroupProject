using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class imm6 : MonoBehaviour
{
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = (9-num).ToString();

    }
}
