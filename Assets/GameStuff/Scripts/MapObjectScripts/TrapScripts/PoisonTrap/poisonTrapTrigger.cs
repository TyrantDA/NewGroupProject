using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonTrapTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int Ammuntion;
    public ItemInfo Poison;
    public ParticleSystem gas;
    public AudioSource GasRelease;

    void Start()
    {
        gas.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Ammuntion > 0)
        {
            if (other.transform.CompareTag("Player"))
            {
                other.gameObject.GetComponent<HealthOfPlayer>().StartPoisonDamage();
                gas.Play();
                GasRelease.Play();
            }
            else if (other.transform.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<HealthOFEnemy>().StartPoisonDamage();
                gas.Play();
                GasRelease.Play();
            }
        }
        else
        {
            Debug.Log("no ammo");
        }

        if (other.transform.CompareTag("Player"))
        {
            int hold = other.gameObject.GetComponent<ItemListUI>().HasItem(Poison);
            if (hold > 0)
            {
                Ammuntion += hold;
                other.gameObject.GetComponent<ItemListUI>().AddItem(Poison, -hold);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Ammuntion > 0)
        {
            if (other.transform.CompareTag("Player"))
            {
                other.gameObject.GetComponent<HealthOfPlayer>().EndPoisonDamage();
            }
            else if (other.transform.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<HealthOFEnemy>().EndPoisonDamage();
            }
        }
    }
}
