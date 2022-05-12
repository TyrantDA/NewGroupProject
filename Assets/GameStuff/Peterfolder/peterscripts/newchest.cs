using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newchest : MonoBehaviour
{
    public bool close = true;
    public bool playhit;
    private Animation anim;
    public bool go;
    public chestnumberopen chestnum;
    public GameObject chesttext1;
    public GameObject chesttext2;
    public ItemInfo Coin;

    void Start()
    {
        go = false;
        anim = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playhit == true)
        {
            if (close == false)
            {
                chesttext1.gameObject.SetActive(true);

            }
            if (close == true)
            {
                chesttext2.gameObject.SetActive(true);

            }
        }
        if (playhit && Input.GetKey(KeyCode.E))
        {

            go = true;
        }
        if (go == true)
        {
            go = false;
            if (anim.isPlaying)
            {
                return;
            }
            if (close == true)
            {
                chesttext2.gameObject.SetActive(false);

                anim.Play("open");
                close = false;
                chestnum.openr = chestnum.openr + 1;

            }
            if (anim.isPlaying)
            {
                return;
            }
            if (close != true)
            {
                chesttext1.gameObject.SetActive(false);

                anim.Play("Close");
                close = true;
                chestnum.openr = chestnum.openr - 1;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            playhit = true;
        }
        if (other.transform.CompareTag("Enemy"))
        {
            if (close == true)
            {
                go = true;

            }
            other.GetComponent<EnemyInventroy>().AddItem(Coin);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            playhit = false;
            chesttext1.gameObject.SetActive(false);
            chesttext2.gameObject.SetActive(false);

        }
    }
}
