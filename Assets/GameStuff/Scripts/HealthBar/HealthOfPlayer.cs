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
    [SerializeField] float heal;
    public HealthBar bar;
    public AudioSource oof;
    public AudioSource ouch1;
    public AudioSource ouch2;
    public AudioSource ouch3;


    bool trapdamage = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
        bar.SetMaxHealth(currentHealth);
    }

    void PlaySounds()
    {
        int soundPlay = Random.Range(0, 4);

        if(soundPlay == 0)
        {
            oof.Play();
        }
        else if(soundPlay == 1)
        {
            ouch1.Play();
        }
        else if(soundPlay == 2)
        {
            ouch2.Play();
        }
        else if(soundPlay == 3)
        {
            ouch3.Play();
        }
    }

    public void DamagePlayer()
    {
        anim.SetBool("hurt", true);
        PlaySounds();
        trapdamage = false;
        currentHealth -= damageFromEnemy;
        
    }
    public void lavaDamage()
    {
        anim.SetBool("hurt", true);
        PlaySounds();
        trapdamage = false;
        currentHealth -= 320;
        
    }


    public void ArrowDamage()
    {
        anim.SetBool("hurt", true);
        PlaySounds();
        currentHealth -= damageFromArrow;
        trapdamage = true;
        Debug.Log("hit");
    }

    public void SpellDamage()
    {
        anim.SetBool("hurt", true);
        PlaySounds();
        trapdamage = false;
        currentHealth -= damageFromSpell;
        
    }
    public void potdam()
    {
        currentHealth -= 1;
        PlaySounds();

    }
    public void hot()
    {
        currentHealth -= 0.05f;
        PlaySounds();

    }

    public bool HealPlayer()
    {
         if (currentHealth < totalHealth)
        {
            currentHealth += heal;
            trapdamage = false;
            return true;
        }
        return false;
    }

    public void StartPoisonDamage()
    {
        anim.SetBool("hurt", true);
        trapdamage = true;
        StartCoroutine("poisonDamage");
    }

    public void EndPoisonDamage()
    {
        anim.SetBool("hurt", true);
        trapdamage = false;
        StopCoroutine("poisonDamage");
    }

    IEnumerator poisonDamage()
    {
        while (true)
        {
            currentHealth -= damageFromPoison;
            PlaySounds();
            yield return new WaitForSeconds(1); 
        }
    }
    IEnumerator dead()
    {
        anim.SetBool("death", true);
        GetComponent<deathplayer>().acive = false;

        yield return new WaitForSeconds(3);
        int gobnumber = PlayerPrefs.GetInt("GobNumber", 36);
        gobnumber++;
        PlayerPrefs.SetInt("GobNumber", gobnumber);
        SceneManager.LoadScene("YouGotFired");
        Debug.Log("Player is dead");
        if(trapdamage == true)
        {
            int achieve = PlayerPrefs.GetInt("work place accident", 0);
            if(achieve == 0)
            {
                PlayerPrefs.SetInt("work place accident", 1);
            }
        }

        int achieve2 = PlayerPrefs.GetInt("Next please", 0);
        if(achieve2 == 0)
        {
            PlayerPrefs.SetInt("Next please", 1);
        }
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
        anim.SetBool("hurt", true);
        if (anim.GetBool("hurt") == true)
        {
           anim.SetBool("hurt", false);

        }
    }




}
