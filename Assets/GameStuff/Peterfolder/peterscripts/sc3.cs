using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc3 : MonoBehaviour
{
    public Animation anim;
    public Animation anim2;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Go");

    }
    IEnumerator Go()
    {
        anim.Play("spikelee");
        anim2.Play("spikelee");
        yield return new WaitForSeconds(3f);
        StartCoroutine("Go");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
