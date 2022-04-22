using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thronecleancheck : MonoBehaviour
{
    public bool clean;
    public Cleanchair hold;
    // Start is called before the first frame update
    void Start()
    {
        clean = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hold.startcleaning == true)
        {
            clean = true;
        }
        if (clean == true)
        {
            transform.GetChild(10).gameObject.SetActive(true);
        }
    }
}
