using Items;
using System.Linq;
using UnityEngine;
using UnityInterfaces;

public class PlayerInventory : Inventory
{
  
    //private InventoryUI _playerInventory;
    //public int maxInventorySlots;

    //void Awake()
    //{
    //    _playerInventory = gameObject.GetComponent<InventoryUI>();
    //}
    
    //public bool AddItem(Item item)
    //{
    //    bool itemAdded = false;

    //    if (Items.Count < maxInventorySlots || Items.Any(x => x.Name = item.Name))
    //    {

    //        //If the item implements the stackable interface and also matches the id of an item in the inventory
    //        if (matchingItemInInventory)
    //        {
    //            var stackableItem = item;
    //            var itemToUpdate = Items.FirstOrDefault(x => x.Name == item.Name && x.StackSize < x.MaxStackSize);

    //            //If the item to add matches the item in the inventory
    //            if (itemToUpdate != null)
    //            {
    //                var newStackSize = itemToUpdate.StackSize + stackableItem.StackSize;

    //                if (newStackSize > itemToUpdate.MaxStackSize)
    //                {
    //                    var overflowSize = newStackSize - itemToUpdate.MaxStackSize;

    //                    //Max out item stack in inventory
    //                    itemToUpdate.StackSize = itemToUpdate.MaxStackSize;
    //                    _playerInventory.SetUIText();


    //                    //Add the overflow to the new stack in the next slot
    //                    var overFlowItem = new ItemData(itemToUpdate);
    //                    overFlowItem.StackSize = overflowSize;
    //                    AddItem(overFlowItem);
    //                    //_playerInventory.SetStackableUISlot(item.sprite, stackableItem.StackSize, item.itemID, stackableItem.MaxStackSize);


    //                    itemAdded = true;
    //                }
    //                else
    //                {
    //                    itemToUpdate.StackSize += stackableItem.StackSize;
    //                    _playerInventory.SetUIText();
    //                    itemAdded = true;
    //                }
    //            }
    //            else
    //            {
    //                if (Items.Count == maxInventorySlots)
    //                {
    //                    Debug.Log("The inventory is full. The item could not be added");
    //                    Spawner.SpawnItem(item, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y));
    //                }
    //                else
    //                {
    //                    AddNonStackableItem(item);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            //There is not item that can be updated or added to
    //            AddNonStackableItem(item);
    //        }
    //    }
    //    return itemAdded;
    //}
    //public bool AddNonStackableItem(Item item)
    //{
    //    Items.Add(item);
    //    SendUIMessage(item);
    //    return true;
    //}
    //public bool ItemCanBeAdded(ItemData item)
    //{
    //    if (Items.FirstOrDefault(x => x.Name == item.Name && x.StackSize < x.MaxStackSize) || Items.Count < maxInventorySlots)
    //    {
    //        return true;
    //    }

    //    return false;
    //}
    //public void RemoveItem(string itemName)
    //{
    //    var itemToRemove = Items.FirstOrDefault(x => x.Name == itemName);
    //    Items.Remove(itemToRemove);
    //}
    //public void SendUIMessage(ItemData item)
    //{
    //  _playerInventory.SetUISlot(item);
    //}
    //private bool CheckItemForMatchingName(ItemData itemToAdd)
    //{
    //    return Items.Any(x => x.Name == itemToAdd.Name);
    //}
    //public void UseItem(string itemName)
    //{
    //    var item = Items.FirstOrDefault(x => x.Name == itemName);

    //   var itemToUse = Instantiate(item.Prefab);

    //    if(itemToUse.GetComponent<IEquipable>() != null)
    //    {
    //        var equipableItem = itemToUse.GetComponent<IEquipable>();
    //        equipableItem.Equip();
    //    }
    //    else
    //    {
    //        Debug.Log("The item is not an equipable item: " + item.Name);
    //    }
    //}
}
