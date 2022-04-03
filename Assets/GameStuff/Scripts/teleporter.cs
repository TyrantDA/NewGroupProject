using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public GameObject teleporterExit;
    Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.transform.GetChild(0);
    }

    public Transform getSpawnPoint()
    {
        return spawnPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            other.transform.position = teleporterExit.GetComponent<teleporter>().getSpawnPoint().position;
        }
    }
}
