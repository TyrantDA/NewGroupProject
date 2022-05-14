using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullchanger : MonoBehaviour
{
    public bool playhit;
    public GameObject invtext;
    public Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
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
            m_Rigidbody.AddForce(transform.up);

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

        }
    }
}
