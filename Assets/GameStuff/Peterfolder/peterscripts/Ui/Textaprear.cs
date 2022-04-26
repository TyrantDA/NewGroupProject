using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textaprear : MonoBehaviour
{
    public Playersellect hold;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (hold.opener == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);

        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);

        }
        if (hold.closer == true)
        {
            transform.GetChild(1).gameObject.SetActive(true);

        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);

        }
        if (hold.clenaer == true)
        {
            transform.GetChild(11).gameObject.SetActive(true);

        }
        else
        {
            transform.GetChild(11).gameObject.SetActive(false);

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
