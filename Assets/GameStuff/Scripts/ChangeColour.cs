using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour
{
    public Text text;
    private void OnMouseEnter()
    {
        text.color = Color.white;
    }

    private void OnMouseExit()
    {
        text.color = Color.black;
    }

}
