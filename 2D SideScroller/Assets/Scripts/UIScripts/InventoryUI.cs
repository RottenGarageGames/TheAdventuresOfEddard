using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> inventorySlots;
    public PlayerInventory playerInventory;

    public void SetUISlot(Sprite itemSprite, int count, int imageID)
    {
        foreach (GameObject item in inventorySlots)
        {
            if (item.GetComponent<Image>().sprite == null)
            {
                var currentSlot = item.GetComponent<Image>();
                var tempColor = currentSlot.color;
                tempColor.a = 1f;
                currentSlot.sprite = itemSprite;
                currentSlot.color = tempColor;

                item.GetComponent<ImageID>().itemID = imageID;

                if (count > 1)
                {
                    item.GetComponentInChildren<Text>().text = count.ToString();
                }
                break;
            }
        }
    }
    public void SetStackableUISlot(Sprite itemSprite, int count, int imageID, int maxStack)
    {
        foreach (GameObject item in inventorySlots)
        {
            if (item.GetComponent<Image>().sprite == null)
            {
                var currentSlot = item.GetComponent<Image>();
                var tempColor = currentSlot.color;
                tempColor.a = 1f;
                currentSlot.sprite = itemSprite;
                currentSlot.color = tempColor;

                item.GetComponent<ImageID>().itemID = imageID;
                item.GetComponent<ImageID>().maxStack = maxStack;
                item.GetComponent<ImageID>().currentStack += count;

                if (count > 1)
                {
                    item.GetComponentInChildren<Text>().text = count.ToString();
                }
                break;
            }
        }
    }
    public void SetUIText(int id, int stackSize)
    {
        var slotToUpdate = inventorySlots.FirstOrDefault(x => x.GetComponent<ImageID>().itemID == id && x.GetComponent<ImageID>().currentStack + stackSize <= x.GetComponent<ImageID>().maxStack);
        slotToUpdate.GetComponent<ImageID>().currentStack += stackSize;
        slotToUpdate.GetComponentInChildren<Text>().text = (slotToUpdate.GetComponent<ImageID>().currentStack).ToString();
    }
    public void DecreaseItemCount(GameObject slotToUpdate)
    {
        slotToUpdate.GetComponentInChildren<Text>().text = (slotToUpdate.GetComponent<ImageID>().currentStack).ToString();
    }
    public void RemoveItemFromUISlot(GameObject slotToUpdate)
    {
        var slotImageID = slotToUpdate.GetComponent<ImageID>();
        slotImageID.itemID = 0;
        slotImageID.maxStack = 0;
        slotImageID.currentStack = 0;
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
