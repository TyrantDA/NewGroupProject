using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newminescript : MonoBehaviour
{
    public bool armed;
    public GameObject spawnpoint;
    public GameObject VFX;
    public List<GameObject> AffectedObjects;

    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator Delaythis()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject hold = Instantiate(VFX, spawnpoint.transform.position, transform.rotation);
        foreach (GameObject objet in AffectedObjects)
        {
            objet.GetComponent<Rigidbody>().AddForce(transform.up * 6000);
            objet.GetComponent<HealthOfPlayer>().ArrowDamage();

        }
        Destroy(gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (armed == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine("Delaythis");
                AffectedObjects.Add(collision.gameObject);

            }
            if (collision.gameObject.CompareTag("Enemy"))
            {
                StartCoroutine("Delaythis");
                AffectedObjects.Add(collision.gameObject);
            }
            else if (collision.transform.CompareTag("EnemyHealer"))
            {
                StartCoroutine("Delaythis");
                AffectedObjects.Add(collision.gameObject);
            }
        }
        //Check to see if the tag on the collider is equal to Enemy

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
