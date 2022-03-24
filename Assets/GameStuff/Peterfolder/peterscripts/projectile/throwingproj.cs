using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwingproj : MonoBehaviour
{
    public GameObject projprfab;
    public GameObject bombfab;

    public Vector3 forward;
    public static throwingproj x;
    public bool going = false;
    public float i;
    // Start is called before the first frame update
    void Start()
    {
        x = this;

    }

    // Update is called once per frame
    void Update()
    {
        forward = transform.forward;
        if (Input.GetKey("g"))
        {
            if(going != true)
            {
                going = true;
                StartCoroutine("Delaythis");
            }
        }
        if (Input.GetKeyUp("g"))
        {
            going = false;

            StopCoroutine("Delaythis");
            var newSquare2 = Instantiate(bombfab, (this.transform.position + transform.forward), Quaternion.identity);

        }


    }
    IEnumerator Delaythis()
    {
        i = 0;
        while(i < 6)
        {
            yield return new WaitForSeconds(0.25f);
            var newSquare = Instantiate(projprfab, (this.transform.position + transform.forward), Quaternion.identity);

            i = i + 0.5f;
        }
        while (i > 5)
        {
            yield return new WaitForSeconds(0.25f);
            var newSquare = Instantiate(projprfab, (this.transform.position + transform.forward), Quaternion.identity);

        }


    }


}
