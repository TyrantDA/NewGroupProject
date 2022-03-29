using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float hitRange;
    public float timeDelay;
    private bool isCoolDown;

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
            Debug.Log("Attack");
            Debug.DrawRay(transform.position, forward, Color.green);
            if (hit.transform.gameObject.tag == "Enemy")
            {
                Debug.Log("hit");
            }
        }

        StartCoroutine("calldown");
    }

    IEnumerator calldown()
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
