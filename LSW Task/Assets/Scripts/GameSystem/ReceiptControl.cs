using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiptControl : MonoBehaviour
{
    public List<GameObject> boughtClothes = new List<GameObject>();
    public StoreControl StoreControl;
    public GameObject ItemsHolder;
    public GameObject NotificationWindow;
    public GameObject receiptItemPrefab;
    public Text TotalField;
    private int priceSum = 0;


    public void OnComparisonFinished()
    {
        clearReceipt();
        NotificationWindow.SetActive(false);

        priceSum = 0;
        this.gameObject.SetActive(true);
        
        foreach (GameObject item in boughtClothes)
        {   
            priceSum += item.GetComponent<ClothesControl>().Price;
            GameObject itemInList = Instantiate(receiptItemPrefab, ItemsHolder.transform);
            itemInList.transform.Find("Name").GetComponent<Text>().text = item.GetComponent<ClothesControl>().Name;
            itemInList.transform.Find("Price").GetComponent<Text>().text = "$ "+ item.GetComponent<ClothesControl>().Price.ToString();
        }

        TotalField.text = "$" + priceSum.ToString();
    }

    public void clearList()
    {
        boughtClothes.Clear();
    }

    //Destroy de UI items inside the receipt holder window
    public void clearReceipt()
    {
        foreach (Transform item in ItemsHolder.transform)
        {
            Destroy(item.gameObject);
            Debug.Log("destructed");
        }
    }

    public void onConfirm()
    {
        if(StoreControl.HasEnoughMoney(priceSum) == true)
        {
            foreach (GameObject item in boughtClothes)
            {
                StoreControl.AddItemToInventory(item);
            }
            
            clearReceipt();
            clearList();
            StoreControl.PurchaseConfirmed(priceSum);
            StoreControl.closeWindows();
        }
        else
        {
            NotificationWindow.SetActive(true);
        }
    }

    public void onCancel()
    {
        clearReceipt();
        clearList();
        StoreControl.dimStoreWindows(false);
        this.gameObject.SetActive(false);
    }
    
    
}
