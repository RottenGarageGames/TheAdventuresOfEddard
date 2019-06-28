﻿using Items;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityInterfaces;

public class PlayerInventory : Inventory
{
  
    private InventoryUI _playerInventory;
    public int maxInventorySlots;

    void Awake()
    {
        Items = new List<ItemData>();
        _playerInventory = gameObject.GetComponent<InventoryUI>();
    }
    
    public bool AddItem(ItemData newItem)
    {
        var item = new ItemData(newItem);

        bool itemAdded = false;

        bool matchingItemInInventory = CheckItemForMatchingID(item);

        if (Items.Count < maxInventorySlots || matchingItemInInventory)
        {

            //If the item implements the stackable interface and also matches the id of an item in the inventory
            if (matchingItemInInventory)
            {
                var stackableItem = item;
                var itemToUpdate = Items.FirstOrDefault(x => x.itemID == item.itemID && x.StackSize < x.MaxStackSize);

                //If the item to add matches the item in the inventory
                if (itemToUpdate != null)
                {
                    var newStackSize = itemToUpdate.StackSize + stackableItem.StackSize;

                    if (newStackSize > itemToUpdate.MaxStackSize)
                    {
                        var overflowSize = newStackSize - itemToUpdate.MaxStackSize;

                        //Max out item stack in inventory
                        itemToUpdate.StackSize = itemToUpdate.MaxStackSize;
                        _playerInventory.SetUIText();


                        //Add the overflow to the new stack in the next slot
                        var overFlowItem = new ItemData(itemToUpdate);
                        overFlowItem.StackSize = overflowSize;
                        AddItem(overFlowItem);
                        //_playerInventory.SetStackableUISlot(item.sprite, stackableItem.StackSize, item.itemID, stackableItem.MaxStackSize);


                        itemAdded = true;
                    }
                    else
                    {
                        itemToUpdate.StackSize += stackableItem.StackSize;
                        _playerInventory.SetUIText();
                        itemAdded = true;
                    }
                }
                else
                {
                    if (Items.Count == maxInventorySlots)
                    {
                        Debug.Log("The inventory is full. The item could not be added");
                        Spawner.SpawnItem(item, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y));
                    }
                    else
                    {
                        AddNonStackableItem(item);
                    }
                }
            }
            else
            {
                //There is not item that can be updated or added to
                AddNonStackableItem(item);
            }
        }
        return itemAdded;
    }
    public bool AddNonStackableItem(ItemData item)
    {
        Items.Add(item);
        SendUIMessage(item);
        return true;
    }
    public bool ItemCanBeAdded(ItemData item)
    {
        if (Items.FirstOrDefault(x => x.itemID == item.itemID && x.StackSize < x.MaxStackSize) || Items.Count < maxInventorySlots)
        {
            return true;
        }

        return false;
    }
    public void RemoveItem(int itemID)
    {
        var itemToRemove = Items.FirstOrDefault(x => x.itemID == itemID);
        Items.Remove(itemToRemove);
    }
    public void SendUIMessage(ItemData item)
    {
      _playerInventory.SetUISlot(item);
    }
    private bool CheckItemForMatchingID(ItemData itemToAdd)
    {
        foreach(ItemData item in Items)
        {
            if(item.itemID == itemToAdd.itemID)
            {
                return true;
            }
        }
        return false;
    }
    public void UseItem(int itemID)
    {
        var item = Items.FirstOrDefault(x => x.itemID == itemID);

       var itemToUse = Instantiate(item.itemPrefab);

        if(itemToUse.GetComponent<IEquipable>() != null)
        {
            var equipableItem = itemToUse.GetComponent<IEquipable>();
            equipableItem.Equip();
        }
        else if(itemToUse.GetComponent<IConsumable>() != null)
        {
            var consumableItem = itemToUse.GetComponent<IConsumable>();
            consumableItem.Consume(gameObject);
        }
        else
        {
            Debug.Log("The item is neither a consumable or an equipable item: " + itemID.ToString());
        }

    }
}
