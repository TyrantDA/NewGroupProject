using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInventroy : MonoBehaviour
{
    [SerializeField] List<ItemInfo> items = new List<ItemInfo>();

    public GameObject ThroneCoin;
    public GameObject SpiderCoin;
    public GameObject SkullCoin;
    public GameObject MushroomCoin;
    public GameObject DragonCoin;
    public GameObject FairySword;
    public GameObject HoopSatff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddItem(ItemInfo newItem)
    {
        items.Add(newItem);
    }

    GameObject getCoin(ItemInfo item)
    {
        if (item.title == "Throne Coin")
        {
            return ThroneCoin;
        }
        else if(item.title == "Spider Coin")
        {
            return SpiderCoin;
        }
        else if(item.title == "Skull Coin")
        {
            return SkullCoin;
        }
        else if(item.title == "Mushroom Coin")
        {
            return MushroomCoin;
        }
        else if(item.title == "Dragon Coin")
        {
            return DragonCoin;
        }
        else if(item.title == "I like rings staff")
        {
            return HoopSatff;
        }
        else
        {
            return FairySword;
        }
    }

    public void OnDeath()
    {
        for(int x = 0; x < items.Count; x++)
        {
            GameObject hold = getCoin(items[x]);
            Instantiate(hold, new Vector3(Random.Range(transform.position.x, (transform.position.x + 3)), 1.27f,
                Random.Range(transform.position.z, (transform.position.z + 3))), transform.rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
