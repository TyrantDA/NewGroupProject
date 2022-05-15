using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officedooropenre : MonoBehaviour
{
    public bool close;
    public bool going;


    private Animation anim;
    public officedoor hold1;
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
                anim.Play("officedooran");
                close = false;
                hold1.close = false;


            }

        }

        else
        {
            going = false;
            if (anim.isPlaying)
            {
                return;
            }
            if (close != true)
            {
                anim.Play("officedooranC");
                close = true;
                hold1.close = true;

            }

        }
    }
}
