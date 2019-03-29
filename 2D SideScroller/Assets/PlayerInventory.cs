using Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Items.Add(item);
        SendUIMessage(item);
    }
    public void RemoveItem(GameObject item)
    {
        Items.Remove(item);
    }
    public void SendUIMessage(GameObject item)
    {
        _playerInventory.SetUISlot(item.GetComponent<SpriteRenderer>().sprite, 0);
    }
}
