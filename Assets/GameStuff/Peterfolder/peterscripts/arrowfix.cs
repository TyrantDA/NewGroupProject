using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowfix : MonoBehaviour
{
    public ItemInfo tool;
    public GameObject fixtext;
    public bool col;
    public bool fixe;

    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        fixe = false;
        col = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (col == true && Input.GetKey(KeyCode.E))
        {

            fixtext.gameObject.SetActive(false);
            if (fixe == false)
            {
                this.GetComponent<arrowLuncher>().enabled = !this.GetComponent<arrowLuncher>().enabled;
                fixe = true;
                p.GetComponent<ItemListUI>().AddItem(tool, -1);
            }
        }

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            int hold = other.gameObject.GetComponent<ItemListUI>().HasItem(tool);
            if (hold > 0)
            {
                if (fixe == false)
                {
                    p = other.gameObject;
                    fixtext.gameObject.SetActive(true);
                    col = true;
                }


            }


        }

    }
    void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            col = false;

            fixtext.gameObject.SetActive(false);

        }
    }
}
