using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombhurt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthOfPlayer>().ArrowDamage();
        }
        else if (collision.transform.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthOFEnemy>().ArrowDamage();
        }
        else if (collision.transform.CompareTag("EnemyHealer"))
        {
            collision.gameObject.GetComponent<HealthOFEnemy>().ArrowDamage();
        }
    }
}
