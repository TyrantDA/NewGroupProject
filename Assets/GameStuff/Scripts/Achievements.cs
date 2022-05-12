using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public GameObject achievementUI;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator unlock()
    {
        spawnPoint.SetActive(true);
        yield return new WaitForSeconds(5);
        spawnPoint.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        int achieve = PlayerPrefs.GetInt("triple Kill", 0);
        Debug.Log("triple Kill :" + achieve);
        if(achieve == 1)
        {
            StartCoroutine("unlock");
            PlayerPrefs.SetInt("triple Kill", 2);
        }

        int achieve2 = PlayerPrefs.GetInt("That not how its suppose to go", 0);
        Debug.Log("That not how its suppose to go :" + achieve2);
        if (achieve2 == 1)
        {
            StartCoroutine("unlock");
            PlayerPrefs.SetInt("That not how its suppose to go", 2);
        }

        int achieve3 = PlayerPrefs.GetInt("work place accident", 0);
        Debug.Log("work place accident :" + achieve3);
        if (achieve3 == 1)
        {
            StartCoroutine("unlock");
            PlayerPrefs.SetInt("work place accident", 2);
        }

        int achieve4 = PlayerPrefs.GetInt("Next please", 0);
        Debug.Log("Next please :" + achieve4);
        if (achieve4 == 1)
        {
            StartCoroutine("unlock");
            PlayerPrefs.SetInt("Next please", 2);
        }
        
        int achieve5 = PlayerPrefs.GetInt("that company property", 0);
        Debug.Log("that company property :" + achieve5);
        if (achieve5 == 1)
        {
            StartCoroutine("unlock");
            PlayerPrefs.SetInt("that company property", 2);
        }

        int achieve6 = PlayerPrefs.GetInt("My Precious", 0);
        Debug.Log("My Precious :" + achieve6);
        if (achieve6 == 1)
        {
            StartCoroutine("unlock");
            PlayerPrefs.SetInt("My Precious", 2);
        }
    }
}
