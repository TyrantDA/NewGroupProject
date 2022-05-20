using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireputout : MonoBehaviour
{
    public bool playhit;
    public bool go;

    public GameObject outtext;
    public GameObject hold;
    public HealthOfPlayer hop;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playhit == true)
        {
            hop.hot();
            anim.SetBool("hurt", false);

            anim.SetBool("hurt", true);

            outtext.gameObject.SetActive(true);

        }
        else
        {


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
            outtext.gameObject.SetActive(false);
            Destroy(hold);
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
            outtext.gameObject.SetActive(false);

        }
    }
}
