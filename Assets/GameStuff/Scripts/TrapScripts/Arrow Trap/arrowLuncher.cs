using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowLuncher : MonoBehaviour
{
    public GameObject arrow;
    [SerializeField] Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    void launchArrow()
    {
        for(int x = 0; x < spawnPoints.Length; x++)
        {
            Vector3 hold = spawnPoints[x].position;
            Instantiate(arrow, hold, Quaternion.Euler(0f, 0f, 270f));
        }
       
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
