using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorsprit : MonoBehaviour
{
    public Doorscript2 hold2;
    public Doorscript1 hold1;
    public bool go;
    public bool close;

    // Start is called before the first frame update
    void Start()
    {
        go = false;
        close = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(go == true)
        {
            go = false;
            if (hold2.GetComponent<Animation>().isPlaying)
            {
                return;
            }
            hold2.go = true;
            hold1.go = true;
            close = !close;

        }
    }
}
