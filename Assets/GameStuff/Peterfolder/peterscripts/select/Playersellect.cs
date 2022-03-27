using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playersellect : MonoBehaviour
{
    public float radiusDetect;
    public float maxium;
    // Start is called before the first frame update
    void Start()
    {
        radiusDetect = 3.0f;
        maxium = 3.0f;
    }
    void detect()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxium) && hit.transform.tag == "Chest")
        {
            print("dd");

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusDetect);
            foreach (var hitCollider in hitColliders)
            {
                print("14");

                if (hitCollider.gameObject.tag == "opener")
                {
                    print("33");

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
    void Update()
    {
        detect();
    }
}
