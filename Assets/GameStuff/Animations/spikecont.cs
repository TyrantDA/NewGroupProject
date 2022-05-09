using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikecont : MonoBehaviour
{
    public Animation anim;
    public Animation anim2;
    public Animation anim3;
    public Animation anim4;
    public Animation anim5;
    public Animation anim6;
    public Animation anim7;
    public Animation anim8;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Go");

    }
    IEnumerator Go()
    {
        anim.Play("spikelee");
        anim3.Play("spikelee");
        anim5.Play("spikelee");
        anim7.Play("spikelee");
        yield return new WaitForSeconds(1.5f);
        anim2.Play("spikelee");
        anim4.Play("spikelee");
        anim6.Play("spikelee");
        anim8.Play("spikelee");
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("Go");


    }
    // Update is called once per frame
    void Update()
    {
    }
}
