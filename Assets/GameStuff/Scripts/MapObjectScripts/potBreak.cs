using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potBreak : MonoBehaviour
{
    public GameObject breakObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BreakPot()
    {
        gameObject.SetActive(false);
        GameObject hold = Instantiate(breakObject, transform.position, transform.rotation);
        Destroy(hold, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
