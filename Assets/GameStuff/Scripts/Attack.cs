using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float timeDelay;

    private bool isCoolDown;
    private bool inRange;
    private Collider target;

    public float forwardForce = 10;
    public float upforce = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void PlayerAttack()
    {
        if(inRange)
        {
            Debug.Log("hit");
            target.transform.gameObject.GetComponent<HealthOFEnemy>().PlayerDamage();
            target.transform.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce);
            target.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * upforce);
            inRange = false;
            StartCoroutine("cooldown");
        }
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
        if (Input.GetMouseButtonDown(0))
        {
            if (!isCoolDown)
            {
                PlayerAttack();
            }
            else
            {
                Debug.Log("cooldown");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.tag == "Enemy")
        {
            //Debug.Log("in range");
            inRange = true;
            target = other;
        }
    }
}
