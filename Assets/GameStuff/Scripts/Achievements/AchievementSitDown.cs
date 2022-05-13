using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSitDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("player " + other.transform.name);
        if (other.transform.CompareTag("Player"))
        {
            bool sitting = other.GetComponent<playersit>().getSitting();
            //Debug.Log(other.transform.tag + " : " + other.transform.name + " : " + sitting);
            if(sitting)
            {
                int achieve = PlayerPrefs.GetInt("Fire and blood", 0);
                if(achieve == 0)
                {
                    PlayerPrefs.SetInt("Fire and blood", 1);
                }

            }
        }
    }
}
