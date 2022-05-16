using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newdoorscript : MonoBehaviour
{
    public bool playhit;
    public bool close = true;
    public bool go;
    public Doorscript1 hold2;
    public Doorscript2 hold1;
    public GameObject chesttext1;
    public GameObject chesttext2;
    // Start is called before the first frame update
    void Start()
    {
        go = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (playhit == true)
        {
            if (close == false)
            {
                chesttext2.gameObject.SetActive(false);

                chesttext1.gameObject.SetActive(true);

            }
            if (close == true)
            {
                chesttext1.gameObject.SetActive(false);

                chesttext2.gameObject.SetActive(true);

            }
        }
        if (playhit && Input.GetKey(KeyCode.E))
        {

            go = true;
            StopCoroutine("delay");

        }
        if (hold1.going == true && hold2.going == true)
        {
            go = false;

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
                StopCoroutine("delay");

            }

        }
        if (other.transform.CompareTag("EnemyHealer"))
        {
            if (close == true)
            {
                go = true;
                StopCoroutine("delay");

            }

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
