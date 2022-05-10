using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ge2 : MonoBehaviour
{
    public float lengthOfTime;
    public Vector3 startMarker;
    public bool goingoff = false;
    // Start is called before the first frame update
    void Start()
    {
        lengthOfTime = 2.0f;

        startMarker = Vector3.one;
        StartCoroutine("Bigger");

    }
    public IEnumerator Bigger()
    {

        float start = Time.time;
        while ((Time.time - start) < lengthOfTime)
        {
            float fracJourney = (Time.time - start) / lengthOfTime;
            transform.localScale = Vector3.Lerp(startMarker, startMarker * 10, fracJourney * 10);
            yield return null;
            StartCoroutine("Delaythis");


        }

    }
    IEnumerator Delaythis()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
