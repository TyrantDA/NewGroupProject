using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc4 : MonoBehaviour
{
    public Animation anim11;
    public Animation anim12;
    public Animation anim13;
    public Animation anim14;
    public Animation anim21;
    public Animation anim22;
    public Animation anim23;
    public Animation anim24;
    public Animation anim31;
    public Animation anim32;
    public Animation anim33;
    public Animation anim34;
    public Animation anim41;
    public Animation anim42;
    public Animation anim43;
    public Animation anim44;
    public Animation anim51;
    public Animation anim52;
    public Animation anim53;
    public Animation anim54;
    public Animation anim61;
    public Animation anim62;
    public Animation anim63;
    public Animation anim64;
    public Animation anim71;
    public Animation anim72;
    public Animation anim73;
    public Animation anim74;
    public Animation anim81;
    public Animation anim82;
    public Animation anim83;
    public Animation anim84;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Go");

    }
    IEnumerator Go()
    {
        anim11.Play("spikelee");
        anim12.Play("spikelee");
        anim13.Play("spikelee");
        anim14.Play("spikelee");
        anim41.Play("spikelee");
        anim42.Play("spikelee");
        anim43.Play("spikelee");
        anim44.Play("spikelee");
        anim71.Play("spikelee");
        anim72.Play("spikelee");
        anim73.Play("spikelee");
        anim74.Play("spikelee");
        yield return new WaitForSeconds(1f);
        anim21.Play("spikelee");
        anim22.Play("spikelee");
        anim23.Play("spikelee");
        anim24.Play("spikelee");
        anim51.Play("spikelee");
        anim52.Play("spikelee");
        anim53.Play("spikelee");
        anim54.Play("spikelee");
        anim81.Play("spikelee");
        anim82.Play("spikelee");
        anim83.Play("spikelee");
        anim84.Play("spikelee"); 
        yield return new WaitForSeconds(1f);
        anim31.Play("spikelee");
        anim32.Play("spikelee");
        anim33.Play("spikelee");
        anim34.Play("spikelee");
        anim61.Play("spikelee");
        anim62.Play("spikelee");
        anim63.Play("spikelee");
        anim64.Play("spikelee");
        yield return new WaitForSeconds(1f);

        StartCoroutine("Go");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
