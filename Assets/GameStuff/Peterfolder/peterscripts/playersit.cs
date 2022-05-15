using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersit : MonoBehaviour
{
    public Animator anim;
    public Collider cap;
    public Collider shp;
    public GameObject hold;

    bool sitting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool getSitting()
    {
        return sitting;
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
                sitting = true;

            }
            else
            {
                anim.SetBool("sit", false);
                cap.enabled = !cap.enabled;
                shp.enabled = !shp.enabled;
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                GetComponent<TopDownCharacterMover>().enabled = !GetComponent<TopDownCharacterMover>().enabled;
                sitting = false;
            }

        }
        if (Input.GetKeyDown("n"))
        {
            if (anim.GetBool("sit") == false)
            {
                hold.gameObject.SetActive(true);
                anim.SetBool("sit", true);
                cap.enabled = !cap.enabled;
                shp.enabled = !shp.enabled;
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                GetComponent<TopDownCharacterMover>().enabled = !GetComponent<TopDownCharacterMover>().enabled;
                sitting = true;
            }
            else
            {
                hold.gameObject.SetActive(false);
                anim.SetBool("sit", false);
                cap.enabled = !cap.enabled;
                shp.enabled = !shp.enabled;
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                GetComponent<TopDownCharacterMover>().enabled = !GetComponent<TopDownCharacterMover>().enabled;
                sitting = false;
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
