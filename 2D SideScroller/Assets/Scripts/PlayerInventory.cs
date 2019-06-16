using Items;
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
    
    public bool AddItem(ItemData item)
    {
        bool itemAdded = false;

        if (Items.Count < maxInventorySlots)
        {
            bool matchingItemInInventory = CheckItemForMatchingID(item);

            //If the item implements the stackable interface and also matches the id of an item in the inventory
            if (matchingItemInInventory)
            {
                var stackableItem = item;
                var itemToUpdate = Items.FirstOrDefault(x => x.itemID == item.itemID && x.StackSize < x.MaxStackSize);

                var itemToUpdateAsStackable = itemToUpdate;

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
                        itemToUpdate.StackSize = itemToUpdateAsStackable.MaxStackSize;

                        //Add the overflow to the new stack in the next slot
                        stackableItem.StackSize = overflowSize;
                        AddNonStackableItem(item);
                        //_playerInventory.SetStackableUISlot(item.sprite, stackableItem.StackSize, item.itemID, stackableItem.MaxStackSize);


                        itemAdded = true;
                    }
                    else
                    {
                        _playerInventory.SetUIText(item.itemID, stackableItem.StackSize);
                        itemToUpdate.StackSize += stackableItem.StackSize;
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
    public bool AddNonStackableItem(ItemData item)
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
    public void SendUIMessage(ItemData item)
    {
        var stackable = item;
        if (item.MaxStackSize == 1)
        {
            _playerInventory.SetUISlot(item.sprite, 1, item.itemID);
        }
        else
        {
            _playerInventory.SetStackableUISlot(item.sprite, stackable.StackSize, item.itemID, stackable.MaxStackSize);
        }
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
