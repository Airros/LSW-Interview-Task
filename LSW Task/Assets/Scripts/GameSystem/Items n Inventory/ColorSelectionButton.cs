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
        GameObject parent = transform.parent.parent.gameObject;

        NewColor = this.GetComponent<Image>().color;

        parent.GetComponent<Image>().color = NewColor;

        InventorySlot.GetComponent<ItemShop>().itemColor = NewColor;
    }
}
