using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthOfPlayer : MonoBehaviour
{
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
        currentHealth -= damageFromEnemy;
    }

    public void ArrowDamage()
    {
        currentHealth -= damageFromArrow;
        Debug.Log("hit");
    }

    public void SpellDamage()
    {
        currentHealth -= damageFromSpell;
    }

    public void StartPoisonDamage()
    {
        StartCoroutine("poisonDamage");
    }

    public void EndPoisonDamage()
    {
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

    void dead()
    {
        SceneManager.LoadScene("YouGotFired");
        Debug.Log("Player is dead");

    }
    // Update is called once per frame
    void Update()
    {
        bar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            dead();
        }

    }

    
    

}
