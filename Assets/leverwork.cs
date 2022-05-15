using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverwork : MonoBehaviour
{
    public Animation anim;
    public fixspikes hold;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(hold.fix == true)
        {
            if (check == true)
            {
                check = false;

                anim.Play("leaver");
            }
        }
        
    }
}
