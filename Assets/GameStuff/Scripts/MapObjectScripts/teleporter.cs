using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleporter : MonoBehaviour
{
    public GameObject teleporterExit;
    public Text textOutput;
    public GameObject pauseScreen;
    public CinemachineFreeLook cam;
    public bool pauseon;
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
            textOutput.text = "Press 'E' to use pipe";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        incol = false;
        player = null;
        textOutput.text = "  ";
    }

    IEnumerator restartCam()
    {
        pauseScreen.SetActive(true);
        cam.enabled = !cam.enabled;
        InputHandler ih = player.GetComponent<InputHandler>();
        TopDownCharacterMover tdcm = player.GetComponent<TopDownCharacterMover>();
        Animator a = player.GetComponent<Animator>();
        Rigidbody rb = player.GetComponent<Rigidbody>();

        ih.enabled = false;
        tdcm.enabled = false;
        a.enabled = false;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();

        yield return new WaitForSeconds(2f);
        ih.enabled = true;
        ih.enabled = true;
        tdcm.enabled = true;
        a.enabled = true;

        cam.enabled = !cam.enabled;
        pauseScreen.SetActive(false);
    }
    IEnumerator restartCam2()
    {
        cam.enabled = !cam.enabled;
        yield return new WaitForSeconds(0.1f);
        cam.enabled = !cam.enabled;
    }

    private void Update()
    {
        if (incol)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                if (pauseon == false)
                {

                    StartCoroutine("restartCam");

                }
                else
                {
                    StartCoroutine("restartCam2");

                }
                player.transform.position = teleporterExit.GetComponent<teleporter>().getSpawnPoint().position;
                incol = false;
                player = null;
            }
        }
    }
}
