using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTrigger : MonoBehaviour
{
    public Animator anim;

    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            target = other.transform.gameObject;
            StartCoroutine("Heal");
        }
    }

    public IEnumerator heal()
    {
        while(true)
        {
            anim.SetBool("heal", true);

            target.GetComponent<HealthOFEnemy>().HealEnemy();
            yield return new WaitForSeconds(10);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            StopCoroutine("Heal");
        }
    }
}
