using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOfPlayer : MonoBehaviour
{
    [SerializeField]float totalHealth;
    float currentHealth;
    [SerializeField] float damageFromEnemy;
    public HealthBar bar;
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

    // Update is called once per frame
    void Update()
    {
        bar.SetHealth(currentHealth);
    }
}
