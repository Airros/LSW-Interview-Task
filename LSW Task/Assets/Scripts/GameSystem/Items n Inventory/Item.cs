using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public Sprite mySprite;
    public GameObject ItemPrefab;
    public Color itemColor;
    public GameObject icon;
    public Text PriceTagText;
    public Image EquippedIcon;
    public bool IsEquipped;
    public GameObject ConfirmationWindow;
    public bool IsShopOpen = false;
    protected PlayerAnimControl AnimControlScript;
    protected StoreControl StoreControlScript;


   
    void Start()
    {
        //Get and set item icon
        
        AnimControlScript = GameObject.FindWithTag(Tags.Player).gameObject.GetComponent<PlayerAnimControl>();

        UpdateIcon();
        UpdatePrice();
        SetStoreControlScript();

    }

    public void SetStoreControlScript()
    {
        StoreControlScript = GameObject.Find("StoreMain").GetComponent<StoreControl>();
    }

    public void UpdateIcon()
    {
        mySprite = ItemPrefab.GetComponent<ClothesControl>().Icon;

        icon.GetComponent<Image>().sprite = mySprite;

    }

    public void UpdatePrice()
    {
        int price = ItemPrefab.GetComponent<ClothesControl>().Price;

        PriceTagText.text = "$ " + price.ToString();
    }

    public void UpdateItemColor()
    {
        icon.GetComponent<Image>().color = itemColor;
    }


    public void OnClickOnShop()
    {
        string tag = ItemPrefab.GetComponent<ClothesControl>().Tag;
        bool hasColorVariation =  ItemPrefab.GetComponent<ClothesControl>().hasColorVariation;
        
        
        StoreControlScript.ChangeClothes(ItemPrefab, tag, itemColor, hasColorVariation);
    }

   public GameObject GetPlayerPart(string TagName)
   {
      
        GameObject PlayerPart = GameObject.FindWithTag(TagName);

        return(PlayerPart);
   }
    

    public void OnClickIcon()
    {   
        IsShopOpen = StoreControlScript.ShopWindow.activeInHierarchy;

        Debug.Log("clicked");
        if(IsShopOpen == true)
        {
            ConfirmationWindow.GetComponent<ConfirmationWindowControl>().TextObj.text = "Sell?";
        }
        else 
        {
            ConfirmationWindow.GetComponent<ConfirmationWindowControl>().TextObj.text = "Equip?";
        }
        
        ConfirmationWindow.SetActive(true);
    }

    public void OnConfirm()
    {
        if(IsShopOpen == true)
        {
            StoreControlScript.SellItem(this.gameObject, ItemPrefab, IsEquipped);
            Debug.Log("Selled");
            ConfirmationWindow.SetActive(false);
        }
        else 
        {   
            string tag = ItemPrefab.GetComponent<ClothesControl>().Tag;
            StoreControlScript.ChangeClothes(ItemPrefab, tag, itemColor, true);
            ConfirmationWindow.SetActive(false);
        }
    }

    public void OnCancel()
    {
        ConfirmationWindow.SetActive(false);
    }
    
}
