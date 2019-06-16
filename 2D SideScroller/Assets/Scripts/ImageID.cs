using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageID : MonoBehaviour
{
    public int itemID;
    public int maxStack;
    public int currentStack;
    public Shop shop;
    public InventoryUI inventoryUI;
    public Image ParentImage;

    public void UseItem()
    {
        currentStack--;

        if (currentStack <= 0)
        {
            inventoryUI.UseItem(itemID, gameObject, true);
        }
        else
        {
            inventoryUI.UseItem(itemID, gameObject, false);
        }


    }
    public void BuyItem()
    {
        shop.ProcessTransaction(itemID);
        Debug.Log("Buy Item");
    }
}
