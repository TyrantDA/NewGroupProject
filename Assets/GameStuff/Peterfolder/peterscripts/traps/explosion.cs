using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float lengthOfTime = 0.01f;
    public Vector3 startMarker;
    public bool goingoff = false;
    // Start is called before the first frame update
    void Start()
    {
        startMarker = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        goingoff = this.GetComponentInParent<minescript>().blowup;
        if (goingoff == true)
        {
            StartCoroutine("Bigger");
        }
    }
    public IEnumerator Bigger()
    {

        float start = Time.time;
        while ((Time.time - start) < lengthOfTime)
        {
            float fracJourney = (Time.time - start) / lengthOfTime;
            transform.localScale = Vector3.Lerp(startMarker, startMarker * 10, fracJourney*5);
            yield return null;
            StartCoroutine("Delaythis");


        }

    }
    IEnumerator Delaythis()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        Destroy(transform.parent.gameObject);

    }
}
