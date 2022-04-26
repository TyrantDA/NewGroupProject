using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playersellect : MonoBehaviour
{
    public float radiusDetect;
    public float maxium;
    public bool closer;
    public bool opener;
    public bool clenaer;
    public bool lighter;


    // Start is called before the first frame update
    void Start()
    {
        opener = false;
        closer = false;
        clenaer = false;
        lighter = false;
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

                    if (hitCollider.gameObject.GetComponent<chestscript>().close == true)
                    {
                        opener = true;
                    }
                    else
                    {
                        opener = false;
                    }
                    if (hitCollider.gameObject.GetComponent<chestscript>().close == false)
                    {
                        closer = true;
                    }
                    else
                    {
                        closer = false;
                    }
                    hitCollider.gameObject.GetComponent<identified>().spotted = true;
                    if (Input.GetKey("e"))
                    {
                        hitCollider.gameObject.GetComponent<chestscript>().go = true;

                    }
                    return;

                }
                else
                {
                    opener = false;
                    closer = false;

                }
            }


        }
        else
        {
            opener = false;
            closer = false;

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

                if (hitCollider.gameObject.tag == "opener" || hitCollider.gameObject.tag == "closer")
                {
                    if (hitCollider.gameObject.GetComponent<Doorsprit>().close == true)
                    {
                        opener = true;
                    }
                    else
                    {
                        opener = false;
                    }
                    if (hitCollider.gameObject.GetComponent<Doorsprit>().close == false)
                    {
                        closer = true;
                    }
                    else
                    {
                        closer = false;
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
                clenaer = true;
                if (Input.GetKey("e"))
                {
                    clenaer = false;
                    hitCollider.gameObject.GetComponent<Cleanchair>().startcleaning = true;

                }
                return;

            }
            


        }
        else
        {
            clenaer = false;
        }
    }
    void detect4()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxium) && hit.transform.tag == "dim")
        {
            Debug.Log("f");
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusDetect);
            foreach (var hitCollider in hitColliders)
            {
                lighter = true;
                if (Input.GetKey("e"))
                {
                    lighter = false;
                    hitCollider.gameObject.GetComponent<lighttoruch>().lighten = true;

                }
                return;

            }



        }
        else
        {
            lighter = false;
        }
    }
    void Update()
    {
        detect1();
        detect2();
        detect3();
        detect4();
    }
    private void FixedUpdate()
    {


    }
}  
