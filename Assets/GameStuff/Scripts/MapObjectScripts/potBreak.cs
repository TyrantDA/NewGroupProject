using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potBreak : MonoBehaviour
{
    public GameObject breakObject;
    public GameObject pot;
    public AudioSource pot1;
    public AudioSource pot2;
    public bool done;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
    }

    void potSounds()
    {
        int sound = Random.Range(0, 2);

        if (sound == 0)
        {
            pot1.Play();
        }
        else if (sound == 1)
        {
            pot2.Play();
        }

    }

    public void BreakPot()
    {
        if (done == false)
        {
            done = true;
            potSounds();
            pot.SetActive(false);
            GameObject hold = Instantiate(breakObject, transform.position, transform.rotation);
            Destroy(hold, 5);
            Destroy(this.gameObject, 5);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
