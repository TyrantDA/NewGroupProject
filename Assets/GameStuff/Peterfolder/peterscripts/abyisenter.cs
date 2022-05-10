using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abyisenter : MonoBehaviour
{
    public bool inabys;
    public GameObject abystext;
    // Start is called before the first frame update
    void Start()
    {
        inabys = false;


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine("timeabys");
        }


    }
    IEnumerator timeabys()
    {
        inabys = true;
        abystext.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        abystext.gameObject.SetActive(false);


    }
}
