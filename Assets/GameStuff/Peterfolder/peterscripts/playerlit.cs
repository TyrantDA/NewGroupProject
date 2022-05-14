using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlit : MonoBehaviour
{
    public bool lit;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        lit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("hurt")== true)
        {
            lit = false;

        }

        
    }
}
