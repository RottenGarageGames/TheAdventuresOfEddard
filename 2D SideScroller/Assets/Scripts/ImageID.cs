using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageID : MonoBehaviour
{
    public int itemID;
    public int maxStack;
    public int currentStack;

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
}
