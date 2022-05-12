using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public ItemInfo DamagePotion;
    public ItemInfo StarPotion;

    public ItemInfo ThroneCoin;
    public ItemInfo SpiderCoin;
    public ItemInfo SkullCoin;
    public ItemInfo MushroomCoin;
    public ItemInfo DragonCoin;

    public GameObject healthBar;
    public Attack playerAttack;

    public Text text;

    Dictionary<ItemInfo, int> items = new Dictionary<ItemInfo, int>();
    Dictionary<ItemInfo, UIItem> uiItems = new Dictionary<ItemInfo,UIItem>();

    Dictionary<string,bool> gemList = new Dictionary<string,bool>();

    private void Start()
    {
        gemList.Add("YellowGem", false);
        gemList.Add("GreenGem", false);
        gemList.Add("TurquoiseGem", false);
        gemList.Add("BlueGem", false);
        gemList.Add("RedGem", false);
        gemList.Add("WhiteGem", false);
        gemList.Add("PurpleGem", false);
    }

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

    IEnumerator boost()
    {
        playerAttack.damageBoostSet(true);
        yield return new WaitForSeconds(10);
        playerAttack.damageBoostSet(false);
    }

    private void Update()
    {
        int hold = HasItem(HealingPotion);
        if(hold > 0)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                bool answer = gameObject.GetComponent<HealthOfPlayer>().HealPlayer();
                if(answer)
                {
                    AddItem(HealingPotion, -1);
                    int achieve = PlayerPrefs.GetInt("that company property", 0);
                    if(achieve == 0)
                    {
                        PlayerPrefs.SetInt("that company property", 1);
                    }

                }

            }
        }
        if (!playerAttack.damageBoosteGet())
        {
            hold = HasItem(DamagePotion);
            if (hold > 0)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    StartCoroutine("boost");
                    AddItem(DamagePotion, -1);
                    int achieve = PlayerPrefs.GetInt("that company property", 0);
                    if (achieve == 0)
                    {
                        PlayerPrefs.SetInt("that company property", 1);
                    }
                }
            }
        }

        int have = 0;
        if(gemList["YellowGem"] == true)
        {
            have++;
        }
        if(gemList["GreenGem"] == true)
        {
            have++;
        }
        if(gemList["TurquoiseGem"] == true)
        {
            have++;
        }
        if (gemList["BlueGem"] == true)
        {
            have++;
        }
        if(gemList["RedGem"] == true)
        {
            have++;
        }
        if (gemList["WhiteGem"] == true)
        {
            have++;
        }
        if (gemList["PurpleGem"] == true)
        {
            have++;
        }

        if(have == gemList.Count)
        {
            int achieve = PlayerPrefs.GetInt("My Precious", 0);
            if(achieve == 0)
            {
                PlayerPrefs.SetInt("My Precious", 1);
            }
        }

    }

        private void OnCollisionEnter(Collision collision)
    {
        if (uiItems.Count < 7)
        {
            if (collision.gameObject.CompareTag("ArrowAmmo"))
            {
                Destroy(collision.gameObject);
                AddItem(Ammo, 15);
            }

            if (collision.gameObject.CompareTag("PoisonAmmo"))
            {
                Destroy(collision.gameObject);
                AddItem(Poison, 10);
            }

            if (collision.gameObject.CompareTag("Potion"))
            {
                Destroy(collision.gameObject);
                AddItem(HealingPotion, 1);
            }

            if (collision.gameObject.CompareTag("Spanner"))
            {
                Destroy(collision.gameObject);
                AddItem(Spanner, 1);
            }

            if (collision.gameObject.CompareTag("DamagePotion"))
            {
                Destroy(collision.gameObject);
                AddItem(DamagePotion, 1);
            }

            if (collision.gameObject.CompareTag("StarPotion"))
            {
                Destroy(collision.gameObject);
                AddItem(StarPotion, 1);
            }


            if (collision.gameObject.CompareTag("ThroneCoin"))
            {
                Destroy(collision.gameObject);
                AddItem(ThroneCoin, 1);
            }

            if (collision.gameObject.CompareTag("SpiderCoin"))
            {
                Destroy(collision.gameObject);
                AddItem(SpiderCoin, 1);
            }

            if (collision.gameObject.CompareTag("SkullCoin"))
            {
                Destroy(collision.gameObject);
                AddItem(SkullCoin, 1);
            }

            if (collision.gameObject.CompareTag("MushroomCoin"))
            {
                Destroy(collision.gameObject);
                AddItem(MushroomCoin, 1);
            }

            if (collision.gameObject.CompareTag("DragonCoin"))
            {
                Destroy(collision.gameObject);
                AddItem(DragonCoin, 1);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("ArrowAmmo") || collision.gameObject.CompareTag("PoisonAmmo") || collision.gameObject.CompareTag("Potion") || collision.gameObject.CompareTag("Spanner") ||
                collision.gameObject.CompareTag("DamagePotion") || collision.gameObject.CompareTag("StarPotion") || collision.gameObject.CompareTag("ThroneCoin") || collision.gameObject.CompareTag("SpiderCoin") ||
                collision.gameObject.CompareTag("SkullCoin") || collision.gameObject.CompareTag("MushroomCoin") || collision.gameObject.CompareTag("DragonCoin"))
            {
                text.text = "Inventory Full";
            }
        }



        if (collision.gameObject.CompareTag("YellowGem"))
        {
            gemList["YellowGem"] = true;
            healthBar.transform.Find("YellowGem").gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("GreenGem"))
        {
            gemList["GreenGem"] = true;
            healthBar.transform.Find("GreenGem").gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("TurquoiseGem"))
        {
            gemList["TurquoiseGem"] = true;
            healthBar.transform.Find("TurquoiseGem").gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("BlueGem"))
        {
            gemList["BlueGem"] = true;
            healthBar.transform.Find("BlueGem").gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("RedGem"))
        {
            gemList["RedGem"] = true;
            healthBar.transform.Find("RedGem").gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("WhiteGem"))
        {
            gemList["WhiteGem"] = true;
            healthBar.transform.Find("WhiteGem").gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("PurpleGem"))
        {
            gemList["PurpleGem"] = true;
            healthBar.transform.Find("PurpleGem").gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (uiItems.Count >= 7)
        {
            if (collision.gameObject.CompareTag("ArrowAmmo") || collision.gameObject.CompareTag("PoisonAmmo") || collision.gameObject.CompareTag("Potion") || collision.gameObject.CompareTag("Spanner") ||
                collision.gameObject.CompareTag("DamagePotion") || collision.gameObject.CompareTag("StarPotion") || collision.gameObject.CompareTag("ThroneCoin") || collision.gameObject.CompareTag("SpiderCoin") ||
                collision.gameObject.CompareTag("SkullCoin") || collision.gameObject.CompareTag("MushroomCoin") || collision.gameObject.CompareTag("DragonCoin"))
            {
                text.text = null;
            }
        }
    }
}
