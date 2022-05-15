using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluehalf : MonoBehaviour
{
    public RectTransform panelRectTransform;
    public imm7 hold;
    public bool going;
    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        going = false;

    }
    public void pickupblue()
    {
        if(going== false)
        {
            if(left == true)
            {
                hold.left = true;

            }
            going = true;
            panelRectTransform.SetAsLastSibling();
            hold.num = hold.num + 0.5f;
            Destroy(this.gameObject,3);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
