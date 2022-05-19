using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hingetrapcode : MonoBehaviour
{
    public Animation anim;
    public float resttime;
    public AudioSource open;
    public AudioSource close;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        StartCoroutine("Go");

    }
    IEnumerator Go()
    {
        open.Play();
        anim.Play("hingtrap");
        yield return new WaitForSeconds(resttime);
        close.Play();
        anim.Play("hingtrap2");
        yield return new WaitForSeconds(resttime);
        StartCoroutine("Go");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
