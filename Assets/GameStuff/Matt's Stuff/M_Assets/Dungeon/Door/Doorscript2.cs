using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorscript2 : MonoBehaviour
{
    public bool close;
    public bool close1;
    public bool close2;

    public bool going;

    private Animation anim;
    public newdoorscript hold2;
    public newdoorscript hold1;
    // Start is called before the first frame update
    void Start()
    {
        close = true;
        going = false;
        anim = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hold1.go == true)
        {
            going = true;

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
        else if (hold2.go == true)
        {
            going = true;

            if (anim.isPlaying)
            {
                return;
            }
            if (close == true)
            {
                anim.Play("openback2");
                close = false;
            }
            if (anim.isPlaying)
            {
                return;
            }
            if (close != true)
            {
                anim.Play("closeback2");
                close = true;
            }
        }
        else
        {
            going = false;

        }
    }
}