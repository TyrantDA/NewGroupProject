using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrack : MonoBehaviour
{
    public bool playhit;
    public GameObject racktext;
    public bool go;
    public int num;

    public bool done;
    public ItemListUI ui;
    public GameObject Gspeerhold;
    public ItemInfo GoblinSpear;
    public GameObject sspeerhold;
    public ItemInfo StoneSpear;
    public GameObject Gsspeerhold;
    public ItemInfo GrassSpear;
    public GameObject Bspeerhold;
    public ItemInfo BoneSpear;
    public GameObject Tsword;
    public ItemInfo TentacleSword;
    public GameObject Gsword;
    public ItemInfo GrassSword;
    public GameObject Fsword1;
    public GameObject Fsword2;
    public ItemInfo FairySword;
    public GameObject Esword;
    public ItemInfo EyeSword;
    public GameObject Hstaff;
    public ItemInfo HoopStaff;
    public GameObject p;

    // Start is called before the first frame update
    void Start()
    {
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        num = p.gameObject.GetComponent<ItemListUI>().HasItem(GoblinSpear) + p.gameObject.GetComponent<ItemListUI>().HasItem(StoneSpear) + p.gameObject.GetComponent<ItemListUI>().HasItem(GrassSpear) + p.gameObject.GetComponent<ItemListUI>().HasItem(BoneSpear) + p.gameObject.GetComponent<ItemListUI>().HasItem(TentacleSword) + p.gameObject.GetComponent<ItemListUI>().HasItem(GrassSword) + p.gameObject.GetComponent<ItemListUI>().HasItem(FairySword) + p.gameObject.GetComponent<ItemListUI>().HasItem(EyeSword) + p.gameObject.GetComponent<ItemListUI>().HasItem(HoopStaff);
        if (playhit == true)
        {
            if (num > 0)
            {
                racktext.gameObject.SetActive(true);
            }
            else
            {
                racktext.gameObject.SetActive(false);

            }
        }
        else
        {
            if (go == false)
            {
                racktext.gameObject.SetActive(false);

            }

        }
        if (go == true)
        {
            racktext.gameObject.SetActive(false);

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
            if (p.gameObject.GetComponent<ItemListUI>().HasItem(GoblinSpear) > 0)
            {
                sspeerhold.SetActive(true);
                p.gameObject.GetComponent<ItemListUI>().AddItem(GoblinSpear, -1);
            }
            if (p.gameObject.GetComponent<ItemListUI>().HasItem(StoneSpear) > 0)
            {
                Gspeerhold.SetActive(true);
                p.gameObject.GetComponent<ItemListUI>().AddItem(StoneSpear, -1);
            }
            if (p.gameObject.GetComponent<ItemListUI>().HasItem(GrassSpear) > 0)
            {
                Gsspeerhold.SetActive(true);
                p.gameObject.GetComponent<ItemListUI>().AddItem(GrassSpear, -1);
            }
            if (p.gameObject.GetComponent<ItemListUI>().HasItem(BoneSpear) > 0)
            {
                Bspeerhold.SetActive(true);
                p.gameObject.GetComponent<ItemListUI>().AddItem(BoneSpear, -1);
            }
            if (p.gameObject.GetComponent<ItemListUI>().HasItem(TentacleSword) > 0)
            {
                Tsword.SetActive(true);
                p.gameObject.GetComponent<ItemListUI>().AddItem(TentacleSword, -1);
            }
            if (p.gameObject.GetComponent<ItemListUI>().HasItem(GrassSword) > 0)
            {
                Gsword.SetActive(true);
                p.gameObject.GetComponent<ItemListUI>().AddItem(GrassSword, -1);
            }
            if (done == false)
            {
                if (p.gameObject.GetComponent<ItemListUI>().HasItem(FairySword) > 0)
                {
                    Fsword1.SetActive(true);
                    p.gameObject.GetComponent<ItemListUI>().AddItem(FairySword, -1);
                    done = true;
                }
            }
            else
            {
                if (p.gameObject.GetComponent<ItemListUI>().HasItem(FairySword) > 0)
                {
                    Fsword2.SetActive(true);
                    p.gameObject.GetComponent<ItemListUI>().AddItem(FairySword, -1);
                }
            }
            if (p.gameObject.GetComponent<ItemListUI>().HasItem(EyeSword) > 0)
            {
                Esword.SetActive(true);
                p.gameObject.GetComponent<ItemListUI>().AddItem(EyeSword, -1);
            }
            if (p.gameObject.GetComponent<ItemListUI>().HasItem(HoopStaff) > 0)
            {
                Hstaff.SetActive(true);
                p.gameObject.GetComponent<ItemListUI>().AddItem(HoopStaff, -1);
            }


        }



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
            racktext.gameObject.SetActive(false);

        }
    }

}
