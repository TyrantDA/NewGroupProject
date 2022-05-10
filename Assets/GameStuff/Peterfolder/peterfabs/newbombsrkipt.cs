using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newbombsrkipt : MonoBehaviour
{
    public GameObject VFX;
    public GameObject sposion;

    public bool Hit;
    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator Delaythis()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject hold = Instantiate(VFX, this.transform.position, transform.rotation);
        GameObject hold2 = Instantiate(sposion, this.transform.position, transform.rotation);

        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            StartCoroutine("Delaythis");
        }

    }
}
