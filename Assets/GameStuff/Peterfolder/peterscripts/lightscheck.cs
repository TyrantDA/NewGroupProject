using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightscheck : MonoBehaviour
{
    public lighttoruch hold1;
    public lighttoruch hold2;
    public lighttoruch hold3;
    public lighttoruch hold4;
    public lighttoruch hold5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (hold1.lighten == true)
        {
            if (hold2.lighten == true)
            {
                if (hold3.lighten == true)
                {
                    if (hold4.lighten == true)
                    {
                        if (hold5.lighten == true)
                        {
                            transform.GetChild(14).gameObject.SetActive(true);

                        }
                    }
                }
            }
        }

    }
}