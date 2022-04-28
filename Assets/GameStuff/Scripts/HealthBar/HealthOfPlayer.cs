using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthOfPlayer : MonoBehaviour
{
    public Animator anim;

    [SerializeField]float totalHealth;
    float currentHealth;
    [SerializeField] float damageFromEnemy;
    [SerializeField] float damageFromArrow;
    [SerializeField] float damageFromPoison;
    [SerializeField] float damageFromSpell;
    public HealthBar bar;
    public AudioSource releasePosion;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
        bar.SetMaxHealth(currentHealth);
    }

    public void DamagePlayer()
    {
        anim.SetBool("hurt", true);

        currentHealth -= damageFromEnemy;
    }

    public void ArrowDamage()
    {
        anim.SetBool("hurt", true);

        currentHealth -= damageFromArrow;
        Debug.Log("hit");
    }

    public void SpellDamage()
    {
        anim.SetBool("hurt", true);

        currentHealth -= damageFromSpell;
    }

    public void StartPoisonDamage()
    {
        anim.SetBool("hurt", true);

        StartCoroutine("poisonDamage");
    }

    public void EndPoisonDamage()
    {
        anim.SetBool("hurt", true);

        StopCoroutine("poisonDamage");
    }

    IEnumerator poisonDamage()
    {
        while (true)
        {
            currentHealth -= damageFromPoison;
            releasePosion.Play();
            yield return new WaitForSeconds(1); 
        }
    }
    IEnumerator dead()
    {
        anim.SetBool("death", true);
        yield return new WaitForSeconds(3);
        int gobnumber = PlayerPrefs.GetInt("GobNumber", 36);
        gobnumber++;
        PlayerPrefs.SetInt("GobNumber", gobnumber);
        SceneManager.LoadScene("YouGotFired");
        Debug.Log("Player is dead");
    }


    // Update is called once per frame
    void Update()
    {

        bar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            StartCoroutine("dead");
        }
        if (currentHealth >= 50)
        {
            anim.SetBool("hobble", false);
        }
        if (currentHealth <= 50)
        {
            anim.SetBool("hobble", true);
        }
        if (currentHealth >= 50)
        {
            anim.SetBool("hobble", false);
        }


    }
    private void FixedUpdate()
    {
        if (anim.GetBool("hurt") == true)
        {
            anim.SetBool("hurt", false);

        }
    }




}
