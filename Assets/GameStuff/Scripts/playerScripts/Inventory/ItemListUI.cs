using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListUI : MonoBehaviour
{
    // this is the item system I used in has the UI elliment biuld in all that is need is a prefab of that element  

    public GameObject listContent; // position of UI Item will be placed on the canvas
    public GameObject uiItemPrefab; // prefab of IU object which will deplace data. the UIItem script will need to be attached to this item as well
    public int addAmount = 1; // amount to be added on button press used only in testing
    public ItemInfo Ammo; // an itemInfo object that can be added to the list each individual type of item will need to be add like this for use
    public ItemInfo Poison;
    public ItemInfo HealingPotion;
    public ItemInfo Spanner;

    Dictionary<ItemInfo, int> items = new Dictionary<ItemInfo, int>();
    Dictionary<ItemInfo, UIItem> uiItems = new Dictionary<ItemInfo,UIItem>();



    public void AddItemButton(ItemInfo newItem)
    {
        AddItem(newItem, addAmount);
    }

    public void AddItem(ItemInfo newItem, int amount = 1)
    {
        //Debug.Log("The amount added " + amount);
        if (!items.ContainsKey(newItem))
        {
            if (amount < 1)
                return;
            items.Add(newItem, amount);
            uiItems.Add(newItem, Instantiate(uiItemPrefab, listContent.transform).GetComponent<UIItem>());
            uiItems[newItem].SetItem(newItem, items[newItem]);
        }
        else
        {
            items[newItem] += amount;

            if(items[newItem]<=0)
            {
                items.Remove(newItem);
                Destroy(uiItems[newItem].gameObject);
                uiItems.Remove(newItem);
            }
            else
            {
                uiItems[newItem].SetItem(newItem, items[newItem]);
            }
        }
    }

    public int HasItem(ItemInfo myItem)
    {
        if (items.ContainsKey(myItem))
            return items[myItem];
        else
            return 0;
    }

    private void Update()
    {
        int hold = HasItem(HealingPotion);
        if(hold > 0)
        {
            if(Input.GetKeyDown(KeyCode.H))
            {
                bool answer = gameObject.GetComponent<HealthOfPlayer>().HealPlayer();
                if(answer)
                {
                    AddItem(HealingPotion, -1);
                }

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ArrowAmmo"))
        {
            Destroy(collision.gameObject);
            AddItem(Ammo,5);
        }

        if (collision.gameObject.CompareTag("PoisonAmmo"))
        {
            Destroy(collision.gameObject);
            AddItem(Poison, 5);
        }

        if(collision.gameObject.CompareTag("Potion"))
        {
            Destroy(collision.gameObject);
            AddItem(HealingPotion, 1);
        }

        if(collision.gameObject.CompareTag("Spanner"))
        {
            Destroy(collision.gameObject);
            AddItem(Spanner, 1);
        }
    }
}
