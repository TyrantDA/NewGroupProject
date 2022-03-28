using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorscript2 : MonoBehaviour
{
    public bool close;
    private Animation anim;
    public bool go;

    // Start is called before the first frame update
    void Start()
    {
        close = true;
        go = false;
        anim = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (go == true)
        {
            go = false;
            if (anim.isPlaying)
            {
                return;
            }
            if (close == true)
            {
                anim.Play("open2");
                close = false;
            }
            if (anim.isPlaying)
            {
                return;
            }
            if (close != true)
            {
                anim.Play("Close2");
                close = true;
            }
        }
    }
}
