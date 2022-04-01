using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.AddForce(transform.forward * m_Thrust);
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.transform.CompareTag("Arrow"))
        {
            m_Rigidbody.isKinematic = true;
            m_Rigidbody.detectCollisions = false;
            // desable collider when texture added
            

            gameObject.transform.parent = collision.gameObject.transform;

            if (collision.transform.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<HealthOfPlayer>().ArrowDamage();
            }
            else if (collision.transform.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<HealthOFEnemy>().ArrowDamage();
            }
        }

    }
}
