using Items;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<Image> inventorySlots;
    public PlayerInventory playerInventory;

    public void SetUISlot(Item item)
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.sprite == null)
            {
                var tempColor = slot.color;
                tempColor.a = 1f;
                slot.sprite = item.Sprite;
                slot.color = tempColor;

                GetComponent<ImageID>().itemData = newItemData;

                if (newItemData.StackSize > 1)
                {
                    item.GetComponentInChildren<Text>().text = newItemData.StackSize.ToString();
                }
                break;
            }
        }
    }

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
    public void UseItem(string itemName, GameObject slotToUpdate, bool RemoveItem)
    {
        playerInventory.UseItem(itemName);

        if (RemoveItem)
        {
            RemoveItemFromUISlot(slotToUpdate);
            playerInventory.RemoveItem(itemName);
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
