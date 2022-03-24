using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    public float lengthOfTime = 1.0f;
    public presurepalte hold;
    public bool goingoff = false;
    public bool goneoff = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public IEnumerator up()
    {

        float start = Time.time;
        Vector3 startingPos = this.transform.position;
        while ((Time.time - start) < 100.0f)
        {
            float fracJourney = (Time.time - start) / (lengthOfTime*60);
            transform.position = Vector3.Lerp(startingPos, startingPos + new Vector3(0,5,0), fracJourney);
            Debug.Log(fracJourney);
            yield return null;


        }

    }
    // Update is called once per frame
    void Update()
    {
        goingoff = hold.stoodon;
        if (goingoff == true)
        {
            if (goneoff != true)
            {
                goneoff = true;
                StartCoroutine("up");
            }
        }

    }
}
