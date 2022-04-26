using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowLuncher : MonoBehaviour
{
    public GameObject arrow;
    public AudioSource effect;
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] int amunition;
    public ItemInfo Ammo;
    public float yRotate;
    public refilnotice hold;
    int cycleFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    void launchArrow()
    {
        if (amunition > 0)
        {
            for (int x = 0; x < spawnPoints.Length; x++)
            {
                Vector3 hold = spawnPoints[x].position;
                Instantiate(arrow, hold, transform.rotation);
                effect.Play();
                amunition--;
            }
        }
        else
        {
            hold.openr = hold.openr + 1;
            Debug.Log("no ammo");
        }
       
    }

    IEnumerator delay()
    {
        while (true)
        {
            launchArrow();
            cycleFire++;
            yield return new WaitForSeconds(5);
            if (cycleFire > 0)
            {
                RaycastHit hit;
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 origin = transform.position;
                if (Physics.Raycast(origin, forward, out hit))
                {
                    if (hit.transform.gameObject.tag == "Wall")
                    {
                        StopCoroutine("delay");
                    }
                }
            }
            

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Arrow"))
        {
            cycleFire = 0;
            StartCoroutine("delay");
        }

        if(other.transform.CompareTag("Player"))
        {
            int hold = other.gameObject.GetComponent<ItemListUI>().HasItem(Ammo);
            if (hold > 0)
            {
                amunition += hold;
                other.gameObject.GetComponent<ItemListUI>().AddItem(Ammo, -hold);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.transform.CompareTag("Arrow"))
        {
            StopCoroutine("delay");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
