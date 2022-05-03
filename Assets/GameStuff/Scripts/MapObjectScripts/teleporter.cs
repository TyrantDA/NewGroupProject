using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleporter : MonoBehaviour
{
    public GameObject teleporterExit;
    public Text textOutput;
    Transform spawnPoint;
    GameObject player;
    bool incol;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.transform.GetChild(0);
        incol = false;
    }

    public Transform getSpawnPoint()
    {
        return spawnPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider with me");
        if (other.transform.CompareTag("Player"))
        {
            player = other.transform.gameObject;
            incol = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("collider with me");
        if (other.transform.CompareTag("Player"))
        {
            player = other.transform.gameObject;
            incol = true;
            textOutput.text = "Press Spacebar";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        incol = false;
        player = null;
        textOutput.text = "  ";
    }


    private void Update()
    {
        if (incol)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.transform.position = teleporterExit.GetComponent<teleporter>().getSpawnPoint().position;
                incol = false;
                player = null;
            }
        }
    }
}
