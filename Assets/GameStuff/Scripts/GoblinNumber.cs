using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinNumber : MonoBehaviour
{
    public Text change;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int gobnumber = PlayerPrefs.GetInt("GobNumber", 36);
        change.text = "Goblin : " + gobnumber + "\"";
    }
}
