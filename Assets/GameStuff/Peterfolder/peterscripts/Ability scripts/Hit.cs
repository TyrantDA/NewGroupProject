using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            this.tag = "kill";
            StartCoroutine("Delaythis");

        }
    }
    IEnumerator Delaythis()
    {

        yield return new WaitForSeconds(2);
        this.tag = "Player";


    }
}
