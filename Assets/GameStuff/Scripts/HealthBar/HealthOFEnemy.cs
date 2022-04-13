using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOFEnemy : MonoBehaviour
{

    [SerializeField] float totalHealth;
    
    [SerializeField] float damageFromEnemy;
    [SerializeField] float damageFromArrow;
    [SerializeField] float damageFromPoison;
    [SerializeField] float damageFromPlayer;
    [SerializeField] float damageFromSpell;
    [SerializeField] float heal;

    [SerializeField] float currentHealth;

    // Start is called before the first frame update

    void Start()
    {
        currentHealth = totalHealth;
    }
    public void DamagePlayer()
    {
        currentHealth -= damageFromEnemy;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void ArrowDamage()
    {
        currentHealth -= damageFromArrow;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void SpellDamage()
    {
        currentHealth -= damageFromSpell;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void StartPoisonDamage()
    {
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
            if (currentHealth <= 0)
            {
                Dead();
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void StartHealing()
    {
        Debug.Log("Start heal");
        StartCoroutine("HealEnemy");
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void EndHealing()
    {
        Debug.Log("End Heal");
        StopCoroutine("HealEnemy");
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    IEnumerator HealEnemy()
    {
        while (true)
        {
            if (currentHealth < totalHealth)
            {
                currentHealth += heal;
            }
            if (currentHealth <= 0)
            {
                Dead();
            }
            yield return new WaitForSeconds(10);
        }
    }

    public void PlayerDamage()
    {
        currentHealth -= damageFromPlayer;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
