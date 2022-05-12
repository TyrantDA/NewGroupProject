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
                hold2.close = false;
                hold1.close = false;
                close1 = true;
                close2 = false;

            }
            if (anim.isPlaying)
            {
                return;
            }
            if (close != true)
            {
                if (close1 == true)
                {
                    anim.Play("Close2");
                    close = true;
                    hold2.close = true;
                    hold1.close = true;
                    close1 = false;
                }
                else if (close2 == true)
                {
                    anim.Play("closeback2");
                    close = true;
                    hold2.close = true;
                    hold1.close = true;
                    close2 = false;
                }

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
                hold2.close = false;
                hold1.close = false;
                close1 = false;
                close2 = true;
            }
            if (anim.isPlaying)
            {
                return;
            }
            if (close != true)
            {
                if (close1 == true)
                {
                    anim.Play("Close2");
                    close = true;
                    hold2.close = true;
                    hold1.close = true;
                    close1 = false;
                }
                else if (close2 == true)
                {
                    anim.Play("closeback2");
                    close = true;
                    hold2.close = true;
                    hold1.close = true;
                    close2 = false;
                }

            }
        }
        else
        {
            going = false;

        }
    }
}