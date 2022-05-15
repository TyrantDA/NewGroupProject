using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropskull : MonoBehaviour
{
    public ItemInfo Skull;
    public GameObject skullhold;
    public GameObject invtext2;
    public scaryindex ind;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            int hold = this.gameObject.GetComponent<ItemListUI>().HasItem(Skull);
            if (hold > 0)
            {

                var newskull = Instantiate(skullhold, (this.transform.position + transform.forward), transform.rotation);
                newskull.GetComponent<skullchanger>().invtext = invtext2;
                newskull.GetComponent<skullchanger>().ind = ind;

                ind.AddItem(newskull);
                this.gameObject.GetComponent<ItemListUI>().AddItem(Skull, -1);
            }
        }

    }

}
