using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinstart : MonoBehaviour
{
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("spin");  
    }
}
