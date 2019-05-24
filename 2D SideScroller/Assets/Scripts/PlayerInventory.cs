using Items;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityInterfaces;

public class PlayerInventory : Inventory
{
    public List<Item> Items;
    private InventoryUI _playerInventory;
    public int maxInventorySlots;

    void Awake()
    {
        Items = new List<Item>();
        _playerInventory = gameObject.GetComponent<InventoryUI>();
    }
    
    public bool AddItem(Item item)
    {
        bool itemAdded = false;

        if (Items.Count < maxInventorySlots)
        {
            bool matchingItemInInventory = CheckItemForMatchingID(item);

            //If the item implements the stackable interface and also matches the id of an item in the inventory
            if (item.GetComponent<IStackable>() != null && matchingItemInInventory)
            {
                var stackableItem = item as IStackable;
                var itemToUpdate = Items.FirstOrDefault(x => x.itemID == item.itemID && x.GetComponent<IStackable>().StackSize < x.GetComponent<IStackable>().MaxStackSize);

                var itemToUpdateAsStackable = itemToUpdate as IStackable;

                //If the item to add matches the item in the inventory
                if (itemToUpdate != null)
                {
                    var newStackSize = itemToUpdateAsStackable.StackSize + stackableItem.StackSize;
                    var amountToFillCurrentStack = stackableItem.MaxStackSize - stackableItem.StackSize;

                    if (newStackSize > itemToUpdateAsStackable.MaxStackSize)
                    {
                        var overflowSize = newStackSize - itemToUpdateAsStackable.MaxStackSize;

                        //Max out item stack in inventory
                        _playerInventory.SetUIText(item.itemID, amountToFillCurrentStack);
                        itemToUpdate.GetComponent<IStackable>().StackSize = itemToUpdateAsStackable.MaxStackSize;

                        //Add the overflow to the new stack in the next slot
                        stackableItem.StackSize = overflowSize;
                        AddNonStackableItem(item);
                        //_playerInventory.SetStackableUISlot(item.sprite, stackableItem.StackSize, item.itemID, stackableItem.MaxStackSize);


                        itemAdded = true;
                    }
                    else
                    {
                        _playerInventory.SetUIText(item.itemID, stackableItem.StackSize);
                        itemToUpdate.GetComponent<IStackable>().StackSize += stackableItem.StackSize;
                        itemAdded = true;
                    }
                }
                else
                {
                    //The stackable item to add is not found in the inventory
                    AddNonStackableItem(item);
                }
            }
            else
            {
                //The item is not stackable, add it to the inventory
                AddNonStackableItem(item);
            }
        }
        return itemAdded;
    }
    public bool AddNonStackableItem(Item item)
    {
        Items.Add(item);
        SendUIMessage(item);
        return true;
    }
    public void RemoveItem(int itemID)
    {
        var itemToRemove = Items.FirstOrDefault(x => x.itemID == itemID);
        Items.Remove(itemToRemove);
    }
    public void SendUIMessage(Item item)
    {
        var stackable = item as IStackable;
        if (item as IStackable == null)
        {
            _playerInventory.SetUISlot(item.sprite, 1, item.itemID);
        }
        else
        {
            _playerInventory.SetStackableUISlot(item.sprite, stackable.StackSize, item.itemID, stackable.MaxStackSize);
        }
    }
    private bool CheckItemForMatchingID(Item itemToAdd)
    {
        foreach(Item item in Items)
        {
            if(item.GetComponent<IInventoryItem>().itemID == itemToAdd.GetComponent<IInventoryItem>().itemID)
            {
                return true;
            }
        }
        return false;
    }
    public void UseItem(int itemID)
    {
        var itemToUse = Items.FirstOrDefault(x => x.itemID == itemID);

        if(itemToUse as IEquipable != null)
        {
            var equipableItem = itemToUse as IEquipable;
            equipableItem.Equip();
        }
        else if(itemToUse as IConsumable != null)
        {
            var consumableItem = itemToUse as IConsumable;
            consumableItem.Consume(gameObject);
        }
        else
        {
            Debug.Log("The item is neither a consumable or an equipable item: " + itemID.ToString());
        }

    }
}
