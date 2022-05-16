using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lw2 : MonoBehaviour
{
    public Animation anim;
    public bool check;
    public bool col;
    public bool go;
    public ItemSpawner hold1;
    public ItemSpawner hold2;
    public ItemSpawner hold3;
    public ItemSpawner hold4;
    public ItemSpawner hold5;
    public ItemSpawner hold6;
    public ItemSpawner hold7;
    public ItemSpawner hold8;
    public ItemSpawner hold9;
    public ItemSpawner hold10;
    public ItemSpawner hold11;
    public ItemSpawner hold12;


    public GameObject Clicktext;
    // Start is called before the first frame update
    void Start()
    {
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (col == true)
        {
            Clicktext.gameObject.SetActive(true);

        }
        else
        {
            Clicktext.gameObject.SetActive(false);

        }
        if (col == true && Input.GetKey(KeyCode.E))
        {
            go = true;

        }
        if (go == true)
        {
            if (check == true)
            {
                check = false;

                anim.Play("leaver");
            }
            else
            {
                check = true;
                anim.Play("leaver2");
            }
            hold1.spawnItem();
            hold2.spawnItem();
            hold3.spawnItem();
            hold4.spawnItem();
            hold5.spawnItem();
            hold6.spawnItem();
            hold7.spawnItem();
            hold8.spawnItem();
            hold9.spawnItem();
            hold10.spawnItem();
            hold11.spawnItem();
            hold12.spawnItem();


        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            col = true;


        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            col = false;

            Clicktext.gameObject.SetActive(false);

        }
    }
}


