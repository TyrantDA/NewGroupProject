using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enmysllect : MonoBehaviour
{
    public float radiusDetect;
    public float maxium;


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
                    
                    hitCollider.gameObject.GetComponent<chestscript>().go = true;

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
                    hitCollider.gameObject.GetComponent<identified>().spotted = true;
                    hitCollider.gameObject.GetComponent<Doorsprit>().go = true;
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
    IEnumerator Stay()
    {
        GetComponent<Patrol>().enabled = !GetComponent<Patrol>().enabled;
        GetComponent<Dectection>().enabled = !GetComponent<Dectection>().enabled;
        GetComponent<NavMeshAgent>().enabled = !GetComponent<NavMeshAgent>().enabled;
        yield return new WaitForSeconds(1);
        GetComponent<Patrol>().enabled = !GetComponent<Patrol>().enabled;
        GetComponent<Dectection>().enabled = !GetComponent<Dectection>().enabled;
        GetComponent<NavMeshAgent>().enabled = !GetComponent<NavMeshAgent>().enabled;

    }
}
