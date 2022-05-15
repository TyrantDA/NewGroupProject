using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullchanger : MonoBehaviour
{
    public bool playhit;
    public GameObject invtext;
    public Rigidbody m_Rigidbody;
    public int number;
    public bool go;
    public scaryindex ind;

    // Start is called before the first frame update
    void Start()
    {
        number = 0;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playhit == true)
        {
            invtext.gameObject.SetActive(true);

        }
        else
        {
            invtext.gameObject.SetActive(false);


        }

        if (playhit && Input.GetKey(KeyCode.E))
        {
            invtext.gameObject.SetActive(false);

            this.gameObject.tag = "Skull";
            ind.Skulls.Remove(this.gameObject);
            m_Rigidbody.AddForce(transform.up);

        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            playhit = true;
        }
        if (go == true)
        {
            if (other.transform.CompareTag("skull"))
            {
                number = 3;
                if (other.transform.CompareTag("coffin"))
                {
                    number = 4;

                }
            }
            else if (other.transform.CompareTag("coffin"))
            {
                number = 2;

            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Crypt"))
        {
            number = 1;
            go = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Crypt"))
        {
            number = 0;
            go = false;

        }
    }
        void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            playhit = false;

        }
        if (go == true)
        {
            if (other.transform.CompareTag("skull"))
            {
                number = 1;
                if (other.transform.CompareTag("coffin"))
                {
                    number = 3;

                }
            }
            else if (other.transform.CompareTag("coffin"))
            {
                number = 1;

            }
        }
    }
}
