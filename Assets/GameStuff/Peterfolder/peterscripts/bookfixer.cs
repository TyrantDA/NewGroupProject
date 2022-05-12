using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookfixer : MonoBehaviour
{
    public bool playhit;
    public bool go;
    public int book;
    public Animation anim1;
    public Rigidbody rb1;
    public Animation anim2;
    public Rigidbody rb2;
    public Animation anim3;
    public Rigidbody rb3;
    public Animation anim4;
    public Rigidbody rb4;
    public Animation anim5;
    public Rigidbody rb5;
    public Animation anim6;
    public Rigidbody rb6;
    public Animation anim7;
    public Rigidbody rb7;
    public Animation anim8;
    public Rigidbody rb8;
    public Animation anim9;
    public Rigidbody rb9;
    public Animation anim10;
    public Rigidbody rb10;
    public Animation anim11;
    public Rigidbody rb11;
    public Animation anim12;
    public Rigidbody rb12;
    public GameObject booktext;
    // Start is called before the first frame update
    void Start()
    {
        book = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playhit == true)
        {
            if(book != 13)
            {
                booktext.gameObject.SetActive(true);

            }
            else
            {
                booktext.gameObject.SetActive(false);

            }

        }
        if (playhit && Input.GetKey(KeyCode.E))
        {

            go = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {

            go = false;
        }
        if (go == true)
        {
            if(book == 1)
            {
                rb1.isKinematic = true;

                StartCoroutine("Book1");
                
            }
            if (book == 2)
            {
                rb2.isKinematic = true;

                StartCoroutine("Book2");

            }
            if (book == 3)
            {
                rb3.isKinematic = true;

                StartCoroutine("Book3");

            }
            if (book == 4)
            {
                rb4.isKinematic = true;

                StartCoroutine("Book4");

            }
            if (book == 5)
            {
                rb5.isKinematic = true;

                StartCoroutine("Book5");

            }
            if (book == 6)
            {
                rb6.isKinematic = true;

                StartCoroutine("Book6");

            }
            if (book == 7)
            {
                rb7.isKinematic = true;

                StartCoroutine("Book7");

            }
            if (book == 8)
            {
                rb8.isKinematic = true;

                StartCoroutine("Book8");

            }
            if (book == 9)
            {
                rb9.isKinematic = true;

                StartCoroutine("Book9");

            }
            if (book == 10)
            {
                rb10.isKinematic = true;

                StartCoroutine("Book10");

            }
            if (book == 11)
            {
                rb11.isKinematic = true;

                StartCoroutine("Book11");

            }
            if (book == 12)
            {
                rb12.isKinematic = true;

                StartCoroutine("Book12");

            }
        }
    }
    IEnumerator Book1()
    {
        anim1.Play("bookstack");
        yield return new WaitForSeconds(1);
        book = 2;
    }
    IEnumerator Book2()
    {
        anim2.Play("bookstack2");
        yield return new WaitForSeconds(1);
        book = 3;
    }
    IEnumerator Book3()
    {
        anim3.Play("bookstack.3");
        yield return new WaitForSeconds(1);
        book = 4;
    }
    IEnumerator Book4()
    {
        anim4.Play("bookstack4");
        yield return new WaitForSeconds(1);
        book = 5;
    }
    IEnumerator Book5()
    {
        anim5.Play("bookstack5");
        yield return new WaitForSeconds(1);
        book = 6;
    }
    IEnumerator Book6()
    {
        anim6.Play("bookstack6");
        yield return new WaitForSeconds(1);
        book = 7;
    }
    IEnumerator Book7()
    {
        anim7.Play("bookstack.7");
        yield return new WaitForSeconds(1);
        book = 8;
    }
    IEnumerator Book8()
    {
        anim8.Play("bookstack8");
        yield return new WaitForSeconds(1);
        book = 9;
    }
    IEnumerator Book9()
    {
        anim9.Play("bookstack.9");
        yield return new WaitForSeconds(1);
        book = 10;
    }
    IEnumerator Book10()
    {
        anim10.Play("bookstack10");
        yield return new WaitForSeconds(1);
        book = 11;
    }
    IEnumerator Book11()
    {
        anim11.Play("bookstack11");
        yield return new WaitForSeconds(1);
        book = 12;
    }
    IEnumerator Book12()
    {
        anim12.Play("bookstack12");
        yield return new WaitForSeconds(1);
        book = 13;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            playhit = true;
        }
    }
  
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            playhit = false;
            booktext.gameObject.SetActive(false);

        }
    }
}
