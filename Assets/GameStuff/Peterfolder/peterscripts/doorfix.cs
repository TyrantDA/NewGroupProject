using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorfix : MonoBehaviour
{
    public bool playhit;
    public GameObject fixtext;
    public bool go;
    public bool done;
    public Animation anim1;
    public GameObject hold;
    

    // Start is called before the first frame update
    void Start()
    {
        go = false;
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playhit == true)
        {
            if (done == false)
            {
                fixtext.gameObject.SetActive(true);


            }
        }
        else
        {
            if (go == false)
            {
                fixtext.gameObject.SetActive(false);

            }

        }
        if (go == true)
        {
            if (done == false)
            {
                fixtext.gameObject.SetActive(true);


            }
        }

            if (playhit && Input.GetKey(KeyCode.E))
        {

            go = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            go = false;
        }
        if (go == true)
        {
            if (done == false)
            {
                anim1.Play("doungintest");
                StartCoroutine("Donetime");

            }
        }
        if (go == false)
        {
            anim1.Rewind("doungintest");
            StopAllCoroutines();


        }
        if (done == true)
        {
            StopAllCoroutines();
            fixtext.gameObject.SetActive(false);

            hold.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator Donetime()
    {
        yield return new WaitForSeconds(10);
        done = true;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            playhit = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            playhit = false;

        }
    }
}
