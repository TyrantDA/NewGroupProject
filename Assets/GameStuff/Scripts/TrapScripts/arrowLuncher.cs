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


    private void OnTriggerStay(Collider other)
    {
        //launchArrow();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        launchArrow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
