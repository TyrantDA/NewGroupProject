using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HealthOFEnemy : MonoBehaviour
{
    public Animator anim;
    public Rigidbody RB;

    [SerializeField] float totalHealth;
    
    [SerializeField] float damageFromEnemy;
    [SerializeField] float damageFromEnemyBoosted;
    [SerializeField] float damageFromArrow;
    [SerializeField] float damageFromPoison;
    [SerializeField] float damageFromPlayer;
    [SerializeField] float damageFromSpell;
    [SerializeField] float heal;

    [SerializeField] float currentHealth;

    EnemyInventroy ei;
    public bool hadChicken = false;
    bool dead = false;
    // Start is called before the first frame update

    void Start()
    {
        currentHealth = totalHealth;
        ei = GetComponent<EnemyInventroy>();
    }
    public void DamagePlayer()
    {
        anim.SetBool("hit", true);

        currentHealth -= damageFromEnemy;
        if (currentHealth <= 0 && !dead)
        {
            Dead();
        }
    }

    public void DamagePlayerBoosted()
    {
        anim.SetBool("hit", true);

        currentHealth -= damageFromEnemyBoosted;
        if (currentHealth <= 0 && !dead)
        {
            Dead();
        }
    }

    public void ArrowDamage()
    {
        anim.SetBool("hit", true);
        //Debug.Log("f");
        currentHealth -= damageFromArrow;
        if (currentHealth <= 0 && !dead)
        {
            Dead();
        }
    }
    public void lavaDamage()
    {
        anim.SetBool("hit", true);
        currentHealth -= 300;
        if (currentHealth <= 0 && !dead)
        {
            Dead();
        }
    }

    public void SpellDamage()
    {
        anim.SetBool("hit", true);

        currentHealth -= damageFromSpell;
        if (currentHealth <= 0 && !dead)
        {
            Dead();
        }
    }

    public void StartPoisonDamage()
    {
        anim.SetBool("hit", true);

        StartCoroutine("poisonDamage");
        if (currentHealth <= 0 && !dead)
        {
            Dead();
        }
    }

    public void EndPoisonDamage()
    {
        StopCoroutine("poisonDamage");
        if (currentHealth <= 0 && !dead)
        {
            Dead();
        }
    }

    IEnumerator poisonDamage()
    {

        while (true)
        {
            currentHealth -= damageFromPoison;
            if (currentHealth <= 0 && !dead)
            {
                Dead();
            }
            yield return new WaitForSeconds(3);
        }
    }

   

    public void HealEnemy()
    {
        
            if (currentHealth < totalHealth)
            {
                currentHealth += heal;
            }
            if (currentHealth <= 0 && !dead)
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

    IEnumerator AtleastHeHadChicken()
    {
        hadChicken = true;
        yield return new WaitForSeconds(10);
        hadChicken = false;
    }

    public void startChicken()
    {
        StartCoroutine("AtleastHeHadChicken");
    }
    void Dead()
    {
        dead = true;
        ei.OnDeath();

        int achieve = PlayerPrefs.GetInt("That not how its suppose to go", 0);
        if(achieve == 0)
        {
            PlayerPrefs.SetInt("That not how its suppose to go", 1);
        }

        if(hadChicken)
        {
            int achieve2 = PlayerPrefs.GetInt("At least he had chicken", 0);
            if(achieve2 == 0)
            {
                PlayerPrefs.SetInt("At least he had chicken", 1);
            }
        }

        StartCoroutine("deadth");
    }
    IEnumerator deadth()
    {
        anim.SetBool("death", true);
        GetComponent<Passivication>().stopped = true;
        GetComponent<pas2>().stopped = true;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }
    IEnumerator hit()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("hit", false);

    }

    public bool missingHealth()
    {
        if(currentHealth < totalHealth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void FixedUpdate()
    {
        if (anim.GetBool("hit") == true)
        {
            StartCoroutine("hit");

        }
    }
}
