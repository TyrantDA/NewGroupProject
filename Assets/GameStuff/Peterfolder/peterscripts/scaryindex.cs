using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaryindex : MonoBehaviour
{
    public List<GameObject> Skulls = new List<GameObject>();
    public int indx;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void AddItem(GameObject skull)
    {
        Skulls.Add(skull);
    }
    // Update is called once per frame
    void Update()
    {
        int hold = new int();
        for (int x = 0; x < Skulls.Count;x++)
        {
            hold = hold + Skulls[x].GetComponent<skullchanger>().number;
        }
        indx = hold;
    }
}
