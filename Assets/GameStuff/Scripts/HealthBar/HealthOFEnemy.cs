using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HealthOFEnemy : MonoBehaviour
{
    public enimyalive hold;
    public Animator anim;
    public Rigidbody RB;

    [SerializeField] float totalHealth;
    
    [SerializeField] float damageFromEnemy;
    [SerializeField] float damageFromArrow;
    [SerializeField] float damageFromPoison;
    [SerializeField] float damageFromPlayer;
    [SerializeField] float damageFromSpell;
    [SerializeField] float heal;

    [SerializeField] float currentHealth;
    public AudioSource releasePoison;
    // Start is called before the first frame update

    void Start()
    {
        hold.alive = hold.alive + 1;
        currentHealth = totalHealth;
    }
    public void DamagePlayer()
    {
        anim.SetBool("hit", true);

        currentHealth -= damageFromEnemy;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void ArrowDamage()
    {
        anim.SetBool("hit", true);
        Debug.Log("f");
        currentHealth -= damageFromArrow;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void SpellDamage()
    {
        anim.SetBool("hit", true);

        currentHealth -= damageFromSpell;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void StartPoisonDamage()
    {
        anim.SetBool("hit", true);

        StartCoroutine("poisonDamage");
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void EndPoisonDamage()
    {
        StopCoroutine("poisonDamage");
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    IEnumerator poisonDamage()
    {

        while (true)
        {
            currentHealth -= damageFromPoison;
            releasePoison.Play();
            if (currentHealth <= 0)
            {
                Dead();
            }
            yield return new WaitForSeconds(1);
        }
    }

   

    public void HealEnemy()
    {
        
            if (currentHealth < totalHealth)
            {
                currentHealth += heal;
            }
            if (currentHealth <= 0)
            {
                Dead();
            }
       
    }

    public void PlayerDamage()
    {
        anim.SetBool("hit", true);

        currentHealth -= damageFromPlayer;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        hold.alive = hold.alive - 1;

        StartCoroutine("deadth");
    }
    IEnumerator deadth()
    {
        anim.SetBool("death", true);
        GetComponent<Passivication>().stopped = true;
        GetComponent<pas2>().stopped = true;

        Debug.Log("GG");
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }
    IEnumerator hit()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("hit", false);

    }
    private void FixedUpdate()
    {
        if (anim.GetBool("hit") == true)
        {
            StartCoroutine("hit");

        }
    }
}
