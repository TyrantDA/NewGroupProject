using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwingproj : MonoBehaviour
{
    public GameObject projprfab;
    public GameObject bombfab;
    public ItemInfo Bomb;

    public Vector3 forward;
    public static throwingproj x;
    public bool going = false;
    public float i;
    public AudioSource bang;
    // Start is called before the first frame update
    void Start()
    {
        x = this;

    }

    // Update is called once per frame
    void Update()
    {
        int hold = this.gameObject.GetComponent<ItemListUI>().HasItem(Bomb);
        if (hold > 0)
        {
            forward = transform.forward;
            if (Input.GetKey("g"))
            {
                if (going != true)
                {
                    going = true;
                    StartCoroutine("Delaythis");
                }
            }
            if (Input.GetKeyUp("g"))
            {
                going = false;
                this.gameObject.GetComponent<ItemListUI>().AddItem(Bomb, -1);

                StopCoroutine("Delaythis");

                var newSquare2 = Instantiate(bombfab, (this.transform.position + transform.forward + transform.up), Quaternion.identity);
                //newSquare2.GetComponent<newbombsrkipt>().bang = bang;
            }
        }


    }
    IEnumerator Delaythis()
    {

        i = 0;
        while(i < 6)
        {
            int hold = this.gameObject.GetComponent<ItemListUI>().HasItem(Bomb);
            if (hold == 0)
            {
                StopCoroutine("Delaythis");

            }
            yield return new WaitForSeconds(0.25f);
            var newSquare = Instantiate(projprfab, (this.transform.position + transform.forward + transform.up), Quaternion.identity);

            i = i + 0.5f;
        }
        while (i > 5)
        {
            int hold = this.gameObject.GetComponent<ItemListUI>().HasItem(Bomb);
            if (hold == 0)
            {
                StopCoroutine("Delaythis");

            }
            yield return new WaitForSeconds(0.25f);
            var newSquare = Instantiate(projprfab, (this.transform.position + transform.forward + transform.up), Quaternion.identity);

        }


    }


}
