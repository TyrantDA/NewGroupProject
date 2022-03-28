using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOFEnemy : MonoBehaviour
{

    [SerializeField] float totalHealth;
    float currentHealth;
    [SerializeField] float damageFromEnemy;
    [SerializeField] float damageFromArrow;
    [SerializeField] float damageFromPoison;
    // Start is called before the first frame update

    void Start()
    {
        currentHealth = totalHealth;
    }
    public void DamagePlayer()
    {
        currentHealth -= damageFromEnemy;
    }

    public void ArrowDamage()
    {
        currentHealth -= damageFromArrow;
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
            yield return new WaitForEndOfFrame();
        }
    }
}
