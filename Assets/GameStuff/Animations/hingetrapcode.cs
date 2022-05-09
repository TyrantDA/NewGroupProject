using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hingetrapcode : MonoBehaviour
{
    public Animation anim;
    public float resttime;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        StartCoroutine("Go");

    }
    IEnumerator Go()
    {
        anim.Play("hingtrap");
        yield return new WaitForSeconds(resttime);
        anim.Play("hingtrap2");
        yield return new WaitForSeconds(resttime);
        StartCoroutine("Go");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
