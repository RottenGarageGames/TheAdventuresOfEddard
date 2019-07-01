using Items;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<Image> inventorySlots;
    public PlayerInventory playerInventory;

    public void DecreaseItemCount(GameObject slotToUpdate)
    {
        //slotToUpdate.GetComponentInChildren<Text>().text = (slotToUpdate.GetComponent<ImageID>().itemData.StackSize).ToString();
    }
    public void RemoveItemFromUISlot(GameObject slotToUpdate)
    {
        //var slotImageID = slotToUpdate.GetComponent<ImageID>();
        //slotImageID.itemData = null;
        var tempColor = slotToUpdate.GetComponent<Image>().color;
        tempColor.a = 0f;
        slotToUpdate.GetComponent<Image>().color = tempColor;
        slotToUpdate.GetComponent<Image>().sprite = null;
        slotToUpdate.GetComponentInChildren<Text>().text = "";

    }
    public void UseItem(string itemName, GameObject slotToUpdate, bool RemoveItem)
    {
        //playerInventory.UseItem(itemName);

        if (RemoveItem)
        {
            RemoveItemFromUISlot(slotToUpdate);
            //playerInventory.RemoveItem(itemName);
        }
        else
        {
            DecreaseItemCount(slotToUpdate);
        }
    }
    public void BuyItem(GameObject itemToAdd)
    {

    }
}
