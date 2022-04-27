using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersit : MonoBehaviour
{
    public Animator anim;
    public Collider cap;
    public Collider shp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (anim.GetBool("sit") == false)
            {
                anim.SetBool("sit", true);
                cap.enabled = !cap.enabled;
                shp.enabled = !shp.enabled;
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                GetComponent<TopDownCharacterMover>().enabled = !GetComponent<TopDownCharacterMover>().enabled;

            }
            else
            {
                anim.SetBool("sit", false);
                cap.enabled = !cap.enabled;
                shp.enabled = !shp.enabled;
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                GetComponent<TopDownCharacterMover>().enabled = !GetComponent<TopDownCharacterMover>().enabled;

            }

        }
        if (Input.GetKeyUp("h"))
        {
            anim.SetBool("dance", false);

        }
        if (Input.GetKeyDown("h"))
        {
            anim.SetBool("dance", true);
                    

        }
        if (Input.GetKeyUp("h"))
        {
            anim.SetBool("dance", false);

        }





    }
}
