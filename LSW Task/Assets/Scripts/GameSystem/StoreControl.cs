using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreControl : MonoBehaviour
{
    public GameObject Player;
    public GameObject ClothingGroup;
    public PlayerAnimControl PlayerAnimtrControl;
    public List<GameObject> PlayerClothes = new List<GameObject>();
    public GameObject ShopWindow;
    public GameObject InventoryWindow;
    public GameObject ReceiptWindow;
    public List<GameObject> WindowDimmers = new List<GameObject>();
    public InventoryControl InventoryControl;
    public PlayerStats PlayerStats;
    public UIManager UIManager;
    private ClothesChanger ClothesChangerScript;

    void Start()
    {
        UIManager = GameObject.FindWithTag(Tags.UIManager).GetComponent<UIManager>();
        Player = GameObject.FindWithTag(Tags.Player);
        PlayerAnimtrControl = Player.GetComponent<PlayerAnimControl>();
        dimStoreWindows(false);
        ClothesChangerScript = this.GetComponent<ClothesChanger>();
        
    }

    public void OnInteract()
    {
        ShopWindow.SetActive(true);
        InventoryWindow.SetActive(true);
        dimStoreWindows(false);
        storePlayerClothes();
        UIManager.DeactivateListOfInteractableUI();
    }

   
    //Store the player clothing so it can be used later for comparisons or to undo changes made on the store window
    void storePlayerClothes()
    {
        foreach (Transform child in ClothingGroup.transform)
        {
            if (child.tag == Tags.UpperClothes || child.tag == Tags.LowerClothes || child.tag == Tags.FeetClothes)
            {
                GameObject cloth = Instantiate(child.gameObject, this.transform);
                cloth.SetActive(false);
                PlayerClothes.Add(cloth.gameObject);
            }
        }
    }
    

    //When the player clicks on "Confirm" this make a series of comparisons the new chosen clothing by going trough to the old ones to verify if discrepancies ocurrs and conclude if any purchase has been made.
    //If any discrepancies are encountered add items to the Receipt List so they can be verified
    public void OnClickConfirm()
    {  
        foreach (Transform item in ClothingGroup.transform)
        {   
            ClothesControl itemClothesControl = item.GetComponent<ClothesControl>();

            if (this.transform.childCount > 0)
            {
                foreach(Transform storeditem in this.transform)
                {
                    ClothesControl storedItemClothesControl = storeditem.GetComponent<ClothesControl>();

                    if(itemClothesControl.gameObject.tag == storedItemClothesControl.gameObject.tag)
                    {
                        if (itemClothesControl.Name != storedItemClothesControl.Name || itemClothesControl.SpriteColor != storedItemClothesControl.SpriteColor)
                        {
                            ReceiptWindow.GetComponent<ReceiptControl>().boughtClothes.Add(item.gameObject);
                        }
                    }
                }
            }
            else
            {
                ReceiptWindow.GetComponent<ReceiptControl>().boughtClothes.Add(item.gameObject);
            }    
        }   

        ReceiptWindow.GetComponent<ReceiptControl>().OnComparisonFinished();  
        dimStoreWindows(true); 
    }

    
    //When the player clicks on "Cancel" this uses the stored clothes to return the player clothing to the original state as if no purchase has happend
    public void OnClickCancel()
    {  
        foreach (Transform item in this.transform)
        {
            Color color = item.GetComponent<ClothesControl>().SpriteColor;
            ClothesChangerScript.SwapClothingPiece(item.gameObject,item.tag, color, true);
        }

        closeWindows();
        ReceiptWindow.GetComponent<ReceiptControl>().clearList();
        ReceiptWindow.GetComponent<ReceiptControl>().clearReceipt();
    }
    void destroyStoredClothes()
    {
        foreach (Transform item in this.transform)
        {
            //create item in inventory
            Destroy(item.gameObject);
        }
    }
    public void closeWindows()
    {
        ShopWindow.SetActive(false);
        InventoryWindow.SetActive(false);
        ReceiptWindow.SetActive(false);
        destroyStoredClothes();
        UIManager.ActivateListOfInteractableUI();
        dimStoreWindows(false);
    }

    public void ResetStore()
    {
        ReceiptWindow.GetComponent<ReceiptControl>().clearList();
        ReceiptWindow.GetComponent<ReceiptControl>().clearReceipt();
    }
    
    public void dimStoreWindows(bool active)
    {
        foreach(GameObject item in WindowDimmers)
        {
            item.SetActive(active);
        }
    }

    public void AddItemToInventory(GameObject item)
    {
        InventoryControl.AddItem(item);
    }

    public void ChangeClothes(GameObject ItemPrefab, string TagName, Color color, bool colorVariation)
    {
        ClothesChangerScript.SwapClothingPiece(ItemPrefab,TagName, color, colorVariation);
    }

    public void SellItem(GameObject itemUI, GameObject itemPrefab ,bool isEquipped)
    {
        foreach (Transform item in this.transform)
        {
            if (item.tag == itemPrefab.tag)
            {
                Destroy(item.gameObject);
            }
        }
        int price = itemPrefab.GetComponent<ClothesControl>().Price;
        ClothesChangerScript.RemoveEquippedCloth(itemUI.GetComponent<Item>().ItemPrefab.transform);
        InventoryControl.RemoveItem(itemUI);
        PlayerStats.AddMoney(price);

    }

    public bool HasEnoughMoney(int amount)
    {
        if (amount <= PlayerStats.money) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PurchaseConfirmed(int priceSum)
    {
        PlayerStats.RemoveMoney(priceSum);
    }

}
