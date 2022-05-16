using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject item;
     public Transform spawnPoint;
    public bool skull;
    public GameObject skulltext;
    public scaryindex ind;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void spawnItem()
    {
        var drop = Instantiate(item, spawnPoint.position, spawnPoint.rotation);
        if (skull == true)
        {
            drop.GetComponent<skullchanger>().invtext = skulltext;
            drop.GetComponent<skullchanger>().ind = ind;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
