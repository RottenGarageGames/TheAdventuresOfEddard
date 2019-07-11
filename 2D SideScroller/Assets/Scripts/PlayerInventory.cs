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

        bool matchingItemInInventory = CheckItemForMatchingName(item);

        if (Items.Count < maxInventorySlots || matchingItemInInventory)
        {

            //If the item implements the stackable interface and also matches the id of an item in the inventory
            if (matchingItemInInventory)
            {
                var stackableItem = item;
                var itemToUpdate = Items.FirstOrDefault(x => x.Name == item.Name && x.StackSize < x.MaxStackSize);

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
        if (Items.FirstOrDefault(x => x.Name == item.Name && x.StackSize < x.MaxStackSize) || Items.Count < maxInventorySlots)
        {
            return true;
        }

        return false;
    }
    public void RemoveItem(string itemName)
    {
        var itemToRemove = Items.FirstOrDefault(x => x.Name == itemName);
        Items.Remove(itemToRemove);
    }
    public void SendUIMessage(ItemData item)
    {
      _playerInventory.SetUISlot(item);
    }
    private bool CheckItemForMatchingName(ItemData itemToAdd)
    {
        return Items.Any(x => x.Name == itemToAdd.Name);
    }
    private int GetItemStackCount(ItemData item)
    {
      var matchingItems =  Items.Where(x => x.ID == item.ID);
        int count = 0;

        foreach(var data in matchingItems)
        {
            count += data.StackSize;
        }
        return count;
    }
    public bool UseItem(string itemName)
    {
        bool itemUsed = false;
        var item = Items.FirstOrDefault(x => x.Name == itemName);

       var itemToUse = Instantiate(item.Prefab);

        if(itemToUse.GetComponent<IEquipable>() != null)
        {
            var equipableItem = itemToUse.GetComponent<IEquipable>();
            equipableItem.Equip();
            itemUsed = true;
        }
        else if(itemToUse.GetComponent<IConsumable>() != null)
        {
            var consumableItem = itemToUse.GetComponent<IConsumable>();
            itemUsed = consumableItem.Consume(gameObject);
            
        }
        else
        {
            Debug.Log("The item is neither a consumable or an equipable item: " + item.Name);
            itemUsed = false;
        }

        if(itemUsed)
        {
            item.StackSize--;
        }

        return itemUsed;
    }
    public bool CheckForRequiredIngredients(List<CraftingIngredient> ingredients)
    {
        foreach(var ingredient in ingredients)
        {
           if(!(GetItemStackCount(ingredient.IngredientItem) >= ingredient.RequiredAmount))
            {
                return false;
            }
        }

        return true;
    }
    public void DecreaseItemStackSize(ItemData itemData, int decreaseAmount)
    {
       var matchingItems = Items.Where(x => x.ID == itemData.ID);
       var smallestStack = matchingItems.Aggregate((currMin, x) => (currMin == null || (x.StackSize) < currMin.StackSize ? x : currMin));
       Debug.Log("Smallest Stack " + smallestStack.StackSize);

        if(smallestStack.StackSize > decreaseAmount)
        {
            smallestStack.StackSize -= decreaseAmount;
        }
        else if(smallestStack.StackSize < decreaseAmount)
        {
            var remainder = decreaseAmount - smallestStack.StackSize;
            smallestStack.StackSize = 0;
            Items.Remove(smallestStack);
            DecreaseItemStackSize(itemData, remainder);
        }
        else
        {
            smallestStack.StackSize = 0;
            Items.Remove(smallestStack);
        }

    }
    public void RemoveIngredientsFromInventory(List<CraftingIngredient> craftingIngredients)
    {
        foreach(var ingredient in craftingIngredients)
        {
                DecreaseItemStackSize(ingredient.IngredientItem, ingredient.RequiredAmount);         
        }

        _playerInventory.SetUIImages();
        _playerInventory.SetUIText();
    }
    public bool Craft(ItemData itemData)
    {
        if (CheckForRequiredIngredients(itemData.Recipe))
        {
            RemoveIngredientsFromInventory(itemData.Recipe);
            AddItem(itemData);
            return true;
        }
        return false;
    }
}
