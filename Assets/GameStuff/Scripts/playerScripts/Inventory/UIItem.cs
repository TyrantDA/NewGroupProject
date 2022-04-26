using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIItem : MonoBehaviour
{
    public Text titleText;
    public Text description;
    public Text amountText;
    public Image icon;


    // use to set UI object with data from the itemInfo Scriptable object
    public void SetItem(ItemInfo newItem, int amount)
    {
        titleText.text = newItem.title;
        amountText.text = amount.ToString();
        icon.sprite = newItem.icon;
        description.text = newItem.description;
    }

}
