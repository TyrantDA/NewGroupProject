using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inttonumber : MonoBehaviour
{
    public spiderdoungin hold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = (8 - hold.left).ToString();
        if (hold.left == 8)
        {
            hold.gameObject.SetActive(false);
        }
    }
}
