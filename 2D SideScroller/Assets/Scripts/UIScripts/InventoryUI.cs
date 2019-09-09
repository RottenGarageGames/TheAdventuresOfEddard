using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> inventorySlots;
    public PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = gameObject.GetComponent<PlayerInventory>();
    }
    public void SetUISlot(ItemData newItemData)
    {
        foreach (GameObject item in inventorySlots)
        {
            if (item.GetComponent<Image>().sprite == null)
            {
                
                var currentSlot = item.GetComponent<Image>();
                var tempColor = currentSlot.color;
                tempColor.a = 1f;
                currentSlot.sprite = newItemData.Sprite;
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
    public void SetUIImages()
    {
        foreach (var slot in inventorySlots)
        {
            var slotData = slot.GetComponent<ImageID>();

            if(slotData.itemData == null || slotData.itemData.StackSize == 0)
            {
                var tempColor = slot.GetComponent<Image>().color;
                tempColor.a = 0f;
                slot.GetComponent<Image>().color = tempColor;
                slot.GetComponent<Image>().sprite = null;
                slot.GetComponentInChildren<Text>().text = "";
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
    public void UseItem(string itemName, GameObject slotToUpdate)
    {
        var itemUsed = playerInventory.UseItem(itemName);

        SetUIText();
        SetUIImages();
    }
    public void BuyItem(GameObject itemToAdd)
    {

    }
    public void CraftItem(ItemData itemData)
    {
        playerInventory.Craft(itemData);
    }
}
