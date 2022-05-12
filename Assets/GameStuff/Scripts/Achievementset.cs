using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievementset : MonoBehaviour
{
    public Sprite grey;
    public Sprite colour;
    public Image pos;
    public string AchieveName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int achieve = PlayerPrefs.GetInt(AchieveName, 0);
        if (achieve == 2)
        {
            pos.sprite = colour;
        }
        else
        {
            pos.sprite = grey;
        }
    }
}
