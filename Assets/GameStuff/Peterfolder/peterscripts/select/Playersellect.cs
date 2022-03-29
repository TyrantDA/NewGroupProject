using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playersellect : MonoBehaviour
{
    public float radiusDetect;
    public float maxium;
    public GameObject hold;
    public GameObject hold2;

    // Start is called before the first frame update
    void Start()
    {
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
                        hold.SetActive(true);
                    }
                    if (hitCollider.gameObject.GetComponent<chestscript>().close == false)
                    {
                        hold2.SetActive(true);
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
                        hold.SetActive(true);
                    }
                    if (hitCollider.gameObject.GetComponent<Doorsprit>().close == false)
                    {
                        hold2.SetActive(true);
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
        void Update()
    {
        detect1();
        detect2();
    }
}
