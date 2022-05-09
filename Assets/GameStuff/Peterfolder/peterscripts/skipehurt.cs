using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipehurt : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("dddd");
            collision.gameObject.GetComponent<HealthOfPlayer>().ArrowDamage();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthOFEnemy>().ArrowDamage();
        }
        else if (collision.gameObject.CompareTag("EnemyHealer"))
        {
            collision.gameObject.GetComponent<HealthOFEnemy>().ArrowDamage();
        }
    }
}   
