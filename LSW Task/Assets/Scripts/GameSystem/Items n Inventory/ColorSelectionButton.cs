using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    public Color NewColor;

    public GameObject InventorySlot;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeParentColor()
    {
        NewColor = this.GetComponent<Image>().color;

        InventorySlot.GetComponent<ItemShop>().itemColor = NewColor;

        InventorySlot.GetComponent<ItemShop>().UpdateItemColor();
    }
}
