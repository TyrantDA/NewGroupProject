using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealTrigger : MonoBehaviour
{
    public Animator anim;
    public ParticleSystem spell;
    GameObject target;
    bool playingHeal;
    public NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        spell.Pause();
        playingHeal = false;
    }




    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            if (other.transform.gameObject.GetComponent<HealthOFEnemy>().missingHealth())
            {
                if (!playingHeal)
                {
                    target = other.transform.gameObject;
                    StartCoroutine("heal");
                }
            }
        }
    }

    public IEnumerator heal()
    {
        spell.Play();
        playingHeal = true;
        anim.SetBool("heal", true);
        agent.destination = transform.position;
        try
        {
            target.GetComponent<HealthOFEnemy>().HealEnemy();
        }
        catch
        {
            anim.SetBool("heal", false);
            spell.Stop();
            playingHeal = false;
            StopCoroutine("heal");
        }
      
        yield return new WaitForSeconds(10);
        anim.SetBool("heal", false);
        spell.Stop();
        playingHeal = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            if (!playingHeal)
            {
                anim.SetBool("heal", false);
                spell.Stop();
                playingHeal = false;
                StopCoroutine("heal");
            }
        }
    }
}
