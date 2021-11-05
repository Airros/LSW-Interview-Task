using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShop : Item
{
    public GameObject childOrganizer;
    void Start()
    {
        //Check if the item has Color Variations and activate or deactivate the option
        bool hasColorVariation = ItemPrefab.GetComponent<ClothesControl>().hasColorVariation;
        if(hasColorVariation == true)
        {
            childOrganizer.SetActive(true);
        }
        else
        {
            childOrganizer.SetActive(false);
        }  

        AnimControlScript = GameObject.FindWithTag(Tags.Player).gameObject.GetComponent<PlayerAnimControl>();

         UpdateIcon();
         UpdatePrice();
         SetStoreControlScript();
    }

}