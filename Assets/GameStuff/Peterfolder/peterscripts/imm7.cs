using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class imm7 : MonoBehaviour
{
    public float num;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = (4 - num).ToString();

    }
}
