using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc2 : MonoBehaviour
{
    public Animation anim;
    public Animation anim2;
    public AudioSource Spike1;
    public AudioSource Spike2;
    public bool up1;
    public bool up2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Go");

    }
    IEnumerator Go()
    {
        anim.Play("spikelee");
        up1 = true;

        yield return new WaitForSeconds(1f);
        anim2.Play("spikelee");
        up2 = true;

        yield return new WaitForSeconds(1f);
        StartCoroutine("Go");
    }
    // Update is called once per frame
    void Update()
    {
        if (up1 == true)
        {
            up1 = false;
            Spike1.Play();
            //sound

        }
        if (up2 == true)
        {
            up2 = false;
            Spike2.Play();
            //sound

        }
    }
}
