using Items;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityInterfaces;

public class PlayerInventory : Inventory
{
    public List<GameObject> Items;
    private InventoryUI _playerInventory;

    void Awake()
    {
        Items = new List<GameObject>();
        _playerInventory = gameObject.GetComponent<InventoryUI>();
    }
    
    public void AddItem(GameObject item)
    {
        bool matchingItemInInventory = CheckItemForMatchingID(item);

        if (item.GetComponent<IStackable>() != null && matchingItemInInventory)
        {
            var itemToUpdate = Items.FirstOrDefault(x => x.GetComponent<IInventoryItem>().itemID == item.GetComponent<IInventoryItem>().itemID);
            itemToUpdate.GetComponent<IStackable>().IncreaseCount(item.GetComponent<IStackable>().StackSize);
        }
        else
        {
            Items.Add(item);
            SendUIMessage(item);
        }
    }
    public void RemoveItem(GameObject item)
    {
        Items.Remove(item);
    }
    public void SendUIMessage(GameObject item)
    {
        _playerInventory.SetUISlot(item.GetComponent<SpriteRenderer>().sprite, 0);
    }
    private bool CheckItemForMatchingID(GameObject itemToAdd)
    {
        foreach(GameObject item in Items)
        {
            if(item.GetComponent<IInventoryItem>().itemID == itemToAdd.GetComponent<IInventoryItem>().itemID)
            {

                return true;
            }
        }
        return false;
    }
}
