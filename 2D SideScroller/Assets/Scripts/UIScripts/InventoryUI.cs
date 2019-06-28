using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> inventorySlots;
    public PlayerInventory playerInventory;

    public void SetUISlot(ItemData newItemData)
    {
        foreach (GameObject item in inventorySlots)
        {
            if (item.GetComponent<Image>().sprite == null)
            {
                
                var currentSlot = item.GetComponent<Image>();
                var tempColor = currentSlot.color;
                tempColor.a = 1f;
                currentSlot.sprite = newItemData.sprite;
                currentSlot.color = tempColor;

                item.GetComponent<ImageID>().itemData = newItemData;

                if (newItemData.StackSize > 1)
                {
                    item.GetComponentInChildren<Text>().text = newItemData.StackSize.ToString();
                }
                break;
            }
        }
    }
    //public void SetStackableUISlot(Sprite itemSprite, int count, int imageID, int maxStack)
    //{
    //    foreach (GameObject item in inventorySlots)
    //    {
    //        if (item.GetComponent<Image>().sprite == null)
    //        {
    //            var currentSlot = item.GetComponent<Image>();
    //            var tempColor = currentSlot.color;
    //            tempColor.a = 1f;
    //            currentSlot.sprite = itemSprite;
    //            currentSlot.color = tempColor;

    //            item.GetComponent<ImageID>().itemID = imageID;
    //            item.GetComponent<ImageID>().maxStack = maxStack;
    //            item.GetComponent<ImageID>().currentStack += count;

    //            if (count > 1)
    //            {
    //                item.GetComponentInChildren<Text>().text = count.ToString();
    //            }
    //            break;
    //        }
    //    }
    //}
    public void SetUIText()
    {
       foreach(var slot in inventorySlots)
        {
            if (slot.GetComponent<ImageID>() != null)
            {
                var stackText = slot.GetComponentInChildren<Text>();

                if (slot.GetComponent<ImageID>()?.itemData?.StackSize >= 2)
                {
                    stackText.text = (slot.GetComponent<ImageID>().itemData.StackSize).ToString();
                }
                else
                {
                    stackText.text = " ";
                }
            }
        }
    }
    public void DecreaseItemCount(GameObject slotToUpdate)
    {
        slotToUpdate.GetComponentInChildren<Text>().text = (slotToUpdate.GetComponent<ImageID>().itemData.StackSize).ToString();
    }
    public void RemoveItemFromUISlot(GameObject slotToUpdate)
    {
        var slotImageID = slotToUpdate.GetComponent<ImageID>();
        slotImageID.itemData = null;
        var tempColor = slotToUpdate.GetComponent<Image>().color;
        tempColor.a = 0f;
        slotToUpdate.GetComponent<Image>().color = tempColor;
        slotToUpdate.GetComponent<Image>().sprite = null;
        slotToUpdate.GetComponentInChildren<Text>().text = "";

    }
    public void UseItem(int itemID, GameObject slotToUpdate, bool RemoveItem)
    {
        playerInventory.UseItem(itemID);

        if (RemoveItem)
        {
            RemoveItemFromUISlot(slotToUpdate);
            playerInventory.RemoveItem(itemID);
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
