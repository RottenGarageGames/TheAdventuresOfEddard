using Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    public List<GameObject> Items;

    public PlayerInventory()
    {
        Items = new List<GameObject>();
    }
    public void AddItem(GameObject item)
    {
        Items.Add(item);

    }
    public void RemoveItem(GameObject item)
    {
        Items.Remove(item);
    }
}
