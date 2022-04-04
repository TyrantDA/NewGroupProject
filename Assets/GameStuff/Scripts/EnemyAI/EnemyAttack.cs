using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeDelay;
    public Transform spawnShot;
    public GameObject ShotPrefab;

    private bool isCoolDown;
    private bool inRange;
    private Collider target;
    private float forwardForce = 10;
    private float upforce = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    void PlayerAttack()
    {
        if (inRange)
        {
            Debug.Log("hit");
            target.transform.gameObject.GetComponent<HealthOfPlayer>().DamagePlayer();
            target.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * forwardForce);
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
        //Debug.Log("off coolDown");
    }


    // Update is called once per frame
    public void go()
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

    public void goRange()
    {
        if (!isCoolDown)
        {
            Instantiate(ShotPrefab, spawnShot.position, transform.rotation);
        }
        else
        {
            Debug.Log("cooldown");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            //Debug.Log("in range");
            inRange = true;
            target = other;
        }
    }
}
