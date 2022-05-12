using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class pickupmenu : MonoBehaviour
{
    public RectTransform panelRectTransform;

    void Start()
    {

    }
 

    public void pickup()
    {
        panelRectTransform.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    { 

    }



}
