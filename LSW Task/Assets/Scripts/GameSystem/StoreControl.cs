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

    void Start()
    {
        Player = GameObject.FindWithTag(Tags.Player);
        PlayerAnimtrControl = Player.GetComponent<PlayerAnimControl>();
    }

    public void OnInteract()
    {
        ShopWindow.SetActive(true);
        InventoryWindow.SetActive(true);
        storePlayerClothes();
    }

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

        ReceiptWindow.GetComponent<ReceiptControl>().OnComparisonFinished();   
    }

    
    //When the player clicks on "Cancel" this uses the stored clothes to return the player clothing to the original state as if no purchase has happend
    public void OnClickCancel()
    {  
        foreach (Transform item in this.transform)
        {
            GameObject oldClothing = GameObject.FindWithTag(item.tag);
            Destroy(oldClothing);

            GameObject cloth = Instantiate(item.gameObject, ClothingGroup.transform);

            cloth.SetActive(true);

            PlayerAnimtrControl.AnimtrChange(cloth);
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
    }
}
