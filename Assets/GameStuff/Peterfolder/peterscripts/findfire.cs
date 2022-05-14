using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findfire : MonoBehaviour
{
    public bool playhit;
    public bool go;
    public bool first;
    public bool lit;
    public GameObject firetext1;
    public playerlit p;
    public GameObject firetext2;
    public GameObject firetext3;
    public GameObject flame;
    public firecount count;
    // Start is called before the first frame update
    void Start()
    {
        count.count = count.count + 1;
        first = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (lit == true)
        {
            flame.SetActive(true);
            if (first == true)
            {
                first = false;
                flame.SetActive(true);
                count.count = count.count - 1;
            }
        }

        if (lit == true)
        {


            if (playhit == true)
            {

                firetext3.gameObject.SetActive(false);
                firetext2.gameObject.SetActive(false);
                firetext1.gameObject.SetActive(true);

            }
            else
            {


            }
        }
        else
        {
            if (p.lit == true)
            {


                if (playhit == true)
                {
                    firetext1.gameObject.SetActive(false);
                    firetext2.gameObject.SetActive(false);

                    firetext3.gameObject.SetActive(true);

                }
                else
                {


                }
            }
            else
            {

                if (playhit == true)
                {

                    firetext1.gameObject.SetActive(false);
                    firetext3.gameObject.SetActive(false);

                    firetext2.gameObject.SetActive(true);

                }
                else
                {


                }
            }
        }
        if (playhit && Input.GetKey(KeyCode.E) && lit)
        {

            p.lit = true;
        }
        if (playhit && Input.GetKey(KeyCode.E) && lit == false && p.lit == true)
        {
            p.lit = false;
            lit = true;

        }

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
            firetext1.gameObject.SetActive(false);
            firetext2.gameObject.SetActive(false);
            firetext3.gameObject.SetActive(false);

        }
    }
}
