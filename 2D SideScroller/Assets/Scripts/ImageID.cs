using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageID : MonoBehaviour
{
    public Shop shop;
    public InventoryUI inventoryUI;
    public Image ParentImage;
    public ItemData itemData;

    public void UseItem()
    {
        itemData.StackSize--;

        if (itemData.StackSize <= 0)
        {
            inventoryUI.UseItem(itemData.itemID, gameObject, true);
        }
        else
        {
            inventoryUI.UseItem(itemData.itemID, gameObject, false);
        }


    }
    public void BuyItem()
    {
        shop.ProcessTransaction(itemData);
        Debug.Log("Buy Item");
    }
}
