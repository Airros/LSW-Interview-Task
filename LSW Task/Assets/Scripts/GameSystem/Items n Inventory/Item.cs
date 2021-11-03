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
    public GameObject ConfirmationWindow;
    public bool isItemOnShop = false;
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

    public void SetStoreControlScript()
    {
        StoreControlScript = GameObject.Find("StoreMain").GetComponent<StoreControl>();
    }

    public void UpdateItemColor(Color color)
    {
        itemColor = color;
    }


    public void OnClickOnShop()
    {
        string tag = ItemPrefab.GetComponent<ClothesControl>().Tag;
        bool hasColorVariation =  ItemPrefab.GetComponent<ClothesControl>().hasColorVariation;
        
        SwapClothingPiece(ItemPrefab, tag, itemColor, hasColorVariation);
    }

    public void SwapClothingPiece(GameObject ItemPrefab, string TagName, Color color, bool colorVariation)
   {

        GameObject PlayerPart = GetPlayerPart(TagName);
        GameObject oldClothing = GameObject.FindWithTag(TagName);
        Destroy(oldClothing);

        GameObject cloth = Instantiate(ItemPrefab,PlayerPart.transform.parent);

        if(colorVariation == false || color == new Color(0,0,0,0))
        {
            cloth.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            cloth.GetComponent<SpriteRenderer>().color = color;
        }

        cloth.GetComponent<ClothesControl>().SpriteColor = cloth.GetComponent<SpriteRenderer>().color;
        AnimControlScript.AnimtrChange(cloth);


   }

   public GameObject GetPlayerPart(string TagName)
   {
      
        GameObject PlayerPart = GameObject.FindWithTag(TagName);

        return(PlayerPart);
   }
    

    public void OnClickOnInventoryShop()
    {
        if(isItemOnShop == true)
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
        if(isItemOnShop == true)
        {
            Debug.Log("Selled");
            ConfirmationWindow.SetActive(false);
        }
        else 
        {   
            string tag = ItemPrefab.GetComponent<ClothesControl>().Tag;
            SwapClothingPiece(ItemPrefab, tag, itemColor, true);
            ConfirmationWindow.SetActive(false);
        }
    }

    public void OnCancel()
    {
        ConfirmationWindow.SetActive(false);
    }

    public void OnClickOnInventory()
    {

    }
    
    
}
