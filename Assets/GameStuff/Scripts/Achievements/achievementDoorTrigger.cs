using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achievementDoorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.transform.name);
        if (other.transform.CompareTag("Enemy"))
        {
            //Debug.Log("Enemy " + other.transform.name);
            other.GetComponent<HealthOFEnemy>().startChicken();
        }
        if (other.transform.CompareTag("EnemyHealer"))
        {
            //Debug.Log("Enemy Healer " + other.transform.name);
            other.GetComponent<HealthOFEnemy>().startChicken();
        }
    }
}
