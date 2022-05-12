using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cagedooropener : MonoBehaviour
{
    public bool close;
    public bool going;
    public bool close1;
    public bool close2;

    private Animation anim;
    public cagedoor hold2;
    public cagedoor hold1;
    // Start is called before the first frame update
    void Start()
    {
        close = true;
        going = false;
        close1 = false;
        close2 = false;

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
                anim.Play("open3");
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
                    anim.Play("Close3");
                    close = true;
                    hold2.close = true;
                    hold1.close = true;
                    close1 = false;
                }
                else if (close2 == true)
                {
                    anim.Play("closeback3");
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
                anim.Play("openback3");
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
                    anim.Play("Close3");
                    close = true;
                    hold2.close = true;
                    hold1.close = true;
                    close1 = false;
                }
                else if (close2 == true)
                {
                    anim.Play("closeback3");
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
