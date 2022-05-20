using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hingetrapcode : MonoBehaviour
{
    public Animation anim;
    public float resttime;
    public fixspikes holdfix;
    public AudioSource open;
    public AudioSource close;
    public bool break2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        break2 = true;

    }
    IEnumerator Go()
    {
        anim.Play("hingtrap");
        if (anim.isPlaying)
        {
            open.Play();
        }
        yield return new WaitForSeconds(resttime);
        anim.Play("hingtrap2");
        if (anim.isPlaying)
        {
            close.Play();
        }
        yield return new WaitForSeconds(resttime);
        StartCoroutine("Go");

    }
    // Update is called once per frame
    void Update()
    {
        
        if(holdfix.fix == true)
        {
            if (break2 == true)
            {
                break2 = false;
                StartCoroutine("Go");

            }
        }
    }
}

