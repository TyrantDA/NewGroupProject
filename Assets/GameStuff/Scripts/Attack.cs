using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float timeDelay;

    private bool isCoolDown;
    private bool inRange;
    private Collider target;
    private float forwardForce = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void PlayerAttack()
    {
        if(inRange)
        {
            target.transform.gameObject.GetComponent<HealthOFEnemy>().PlayerDamage();
            target.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * forwardForce);
            inRange = false;
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
            Debug.Log("in range");
            inRange = true;
            target = other;
        }
    }
}
