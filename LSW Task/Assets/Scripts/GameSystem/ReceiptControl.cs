using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiptControl : MonoBehaviour
{
    public List<GameObject> boughtClothes = new List<GameObject>();
    public GameObject StoreControl;
    public GameObject ItemsHolder;
    public GameObject receiptItemPrefab;
    public GameObject TotalField;
    private int priceSum = 0;


    public void OnComparisonFinished()
    {
        clearReceipt();
        priceSum = 0;
        this.gameObject.SetActive(true);
        
        foreach (GameObject item in boughtClothes)
        {   
            priceSum += item.GetComponent<ClothesControl>().Price;
            GameObject itemInList = Instantiate(receiptItemPrefab, ItemsHolder.transform);
            itemInList.transform.Find("Name").GetComponent<Text>().text = item.GetComponent<ClothesControl>().Name;
            itemInList.transform.Find("Price").GetComponent<Text>().text = "$ "+ item.GetComponent<ClothesControl>().Price.ToString();
        }

        TotalField.GetComponent<Text>().text = "$" + priceSum.ToString();

        clearList();
    }

    public void clearList()
    {
        boughtClothes.Clear();
    }

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
        //subtract sum from player money and close windows
        clearReceipt();
        clearList();
        Debug.Log("Bought, subtract " + priceSum + "dollars");
        StoreControl.GetComponent<StoreControl>().closeWindows();
    }

    public void onCancel()
    {
        clearReceipt();
        clearList();
        this.gameObject.SetActive(false);
    }
    
    
}
