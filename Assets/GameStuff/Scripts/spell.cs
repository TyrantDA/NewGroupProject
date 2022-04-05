using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    public Vector3 target;
    public float speed;

    float step;

    // Start is called before the first frame update
    void Start()
    {
        //target = transform.position;
        step = speed * Time.deltaTime;
        Destroy(gameObject, 5.0f);
    }


    // Update is called once per frame
    void Update()
    {
        if(transform.position == target)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthOfPlayer>().SpellDamage();
           
        }
        else if (collision.transform.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthOFEnemy>().SpellDamage();
            
        }
        Destroy(gameObject);
    }

}
