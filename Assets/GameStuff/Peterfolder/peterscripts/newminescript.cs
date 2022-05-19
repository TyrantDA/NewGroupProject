using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newminescript : MonoBehaviour
{
    public bool armed;
    public GameObject spawnpoint;
    public GameObject VFX;
    public List<GameObject> AffectedObjects;
    public AudioSource bang;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Delaythis()
    {
        bang.Play();
        GameObject hold = Instantiate(VFX, spawnpoint.transform.position, transform.rotation);
        foreach (GameObject objet in AffectedObjects)
        {
            objet.GetComponent<Rigidbody>().AddForce(transform.up * 6000);
            objet.GetComponent<HealthOfPlayer>().ArrowDamage();

        }
        
        Destroy(gameObject, 0.5f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (armed == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Delaythis();
                AffectedObjects.Add(collision.gameObject);

            }
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Delaythis();
                AffectedObjects.Add(collision.gameObject);
            }
            else if (collision.transform.CompareTag("EnemyHealer"))
            {
                Delaythis();
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
