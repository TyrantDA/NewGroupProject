using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropmine : MonoBehaviour
{
    public ItemInfo mine;
    public GameObject minehold;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            int hold = this.gameObject.GetComponent<ItemListUI>().HasItem(mine);
            if (hold > 0)
            {

                var newsmine = Instantiate(minehold, (this.transform.position + transform.forward*2), transform.rotation);


                this.gameObject.GetComponent<ItemListUI>().AddItem(mine, -1);
            }
        }

    }

}
