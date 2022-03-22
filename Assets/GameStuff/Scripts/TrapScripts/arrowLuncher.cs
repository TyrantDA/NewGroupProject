using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowLuncher : MonoBehaviour
{
    public GameObject arrow;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    void launchArrow()
    {
        Vector3 hold = spawnPoint.position;
        Instantiate(arrow, hold, Quaternion.Euler(0f, 0f, 270f));
    }

    IEnumerator delay()
    {
        while (true)
        {
            launchArrow();
            yield return new WaitForSeconds(2);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Arrow"))
        {
            StartCoroutine("delay");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.transform.CompareTag("Arrow"))
        {
            StopCoroutine("delay");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
