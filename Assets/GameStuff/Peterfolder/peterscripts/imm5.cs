using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imm5 : MonoBehaviour
{ 
    public firecount hold;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = (hold.count).ToString();
        if (hold.count == 0)
        {
            hold.gameObject.SetActive(false);
        }

    }
}

