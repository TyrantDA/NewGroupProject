using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playersellect : MonoBehaviour
{
    public float radiusDetect;
    public float maxium;
    public bool closer;
    public bool opener;

    // Start is called before the first frame update
    void Start()
    {
        opener = false;
        closer = false;
        radiusDetect = 3.0f;
        maxium = 3.0f;
    }
    void detect1()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxium) && hit.transform.tag == "Chest")
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusDetect);
            foreach (var hitCollider in hitColliders)
            {


                if (hitCollider.gameObject.tag == "opener")
                {

                    if (hitCollider.gameObject.GetComponent<Doorsprit>().close == true)
                    {
                        opener = true;
                    }
                    if (hitCollider.gameObject.GetComponent<Doorsprit>().close == false)
                    {
                        closer = true;
                    }
                    hitCollider.gameObject.GetComponent<identified>().spotted = true;
                    if (Input.GetKey("e"))
                    {
                        hitCollider.gameObject.GetComponent<chestscript>().go = true;

                    }
                    return;

                }
            }


        }
    }
    void detect2()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxium) && hit.transform.tag == "Door")
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusDetect);
            foreach (var hitCollider in hitColliders)
            {

                if (hitCollider.gameObject.tag == "opener")
                {
                    if (hitCollider.gameObject.GetComponent<Doorsprit>().close == true)
                    {
                        opener = true;
                    }
                    if (hitCollider.gameObject.GetComponent<Doorsprit>().close == false)
                    {
                        closer = true;
                    }
                    hitCollider.gameObject.GetComponent<identified>().spotted = true;
                    if (Input.GetKey("e"))
                    {
                        hitCollider.gameObject.GetComponent<Doorsprit>().go = true;

                    }
                    return;

                }
            }


        }
    }
    void detect3()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxium) && hit.transform.tag == "dirty")
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusDetect);
            foreach (var hitCollider in hitColliders)
            {
                Debug.Log("lol");
                if (Input.GetKey("e"))
                {
                    Debug.Log("4");

                    hitCollider.gameObject.GetComponent<Cleanchair>().startcleaning = true;

                }
                return;

            }
            


        }
    }
    void Update()
    {
        detect1();
        detect2();
        detect3();
    }
    private void FixedUpdate()
    {
        opener = false;
        closer = false;
    }
}  
