using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighttoruch : MonoBehaviour
{
    public bool lighten = false;
    // Start is called before the first frame update
    void Start()
    {
        lighten = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lighten == true)
        {
            this.gameObject.tag = "lit";

        }
    }
}
