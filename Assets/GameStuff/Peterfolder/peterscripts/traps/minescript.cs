using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minescript : MonoBehaviour
{
    public static minescript x;

    public bool foundSomething = false;
    public float radiusDetect;
    public bool blowup = false;
    // Start is called before the first frame update
    void Start()
    {
        radiusDetect = 5;
        x = this;

    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator Delaythis()
    {
        yield return new WaitForSeconds(1);
        blowup = true;

    }
    void explosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusDetect);
        int hold = 0;

        for (int x = 0; x < hitColliders.Length; x++)
        {
            if (hitColliders[x].transform.CompareTag("Player"))
            {
                foundSomething = true;
                Debug.Log("gg");
                hold = x;
            }
            if (hitColliders[x].transform.CompareTag("Enemy"))
            {
                foundSomething = true;
                Debug.Log("gg");
                hold = x;
            }

        }
        if (foundSomething == true)
        {
            StartCoroutine("Delaythis");
        }
    }
    private void FixedUpdate()
    {
        if(foundSomething != true)
        {
            explosion();
        }


    }
}
