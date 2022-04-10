using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float hitRange;
    public float timeDelay;
    private bool isCoolDown;
    private float forwardForce = 200;
    public GameObject hitBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Attack()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 origin = transform.position;
 
        if(Physics.Raycast(origin, forward, out hit, hitRange))
        {
            Debug.Log("Attack " + hit.transform.gameObject.name);
            if (hit.transform.gameObject.tag == "Enemy")
            {
                Debug.Log("hit");
                hit.transform.gameObject.GetComponent<HealthOFEnemy>().PlayerDamage();
                hit.transform.gameObject.GetComponent <Rigidbody>().AddForce(Vector3.back * forwardForce);
            }
        }

        StartCoroutine("cooldown");
    }

    IEnumerator cooldown()
    {
        isCoolDown = true;

        yield return new WaitForSeconds(timeDelay);

        isCoolDown = false;
        Debug.Log("off coolDown");
    }

        // Update is called once per frame
     void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!isCoolDown)
            {
                Attack();
            }
            else
            {
                Debug.Log("cooldown");
            }
        }
    }
}
