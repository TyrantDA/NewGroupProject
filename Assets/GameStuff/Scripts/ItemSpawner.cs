using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject item;
     public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void spawnItem()
    {
        Instantiate(item, spawnPoint.position, spawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
