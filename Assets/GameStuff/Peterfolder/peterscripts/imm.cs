using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class imm : MonoBehaviour
{
    public trapmaze hold;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = (14 - hold.left).ToString();
        if (hold.left == 14)
        {
            hold.gameObject.SetActive(false);
        }
    }
}
