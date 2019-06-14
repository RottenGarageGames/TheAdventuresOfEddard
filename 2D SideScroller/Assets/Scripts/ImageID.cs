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
        var parentImage = gameObject.GetComponentInParent(typeof(Image)) as Image;
        shop.ValidTransaction(1);
        inventoryUI.SetUISlot(parentImage.sprite, 1, 1);
        Debug.Log("Buy Item");
    }
}
