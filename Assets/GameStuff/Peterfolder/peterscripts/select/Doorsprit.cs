using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorsprit : MonoBehaviour
{
    public Doorscript2 hold2;
    public Doorscript1 hold1;
    public bool go;

    // Start is called before the first frame update
    void Start()
    {
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(go == true)
        {
            go = false;
            hold2.go = true;
            hold1.go = true;

        }
    }
}
