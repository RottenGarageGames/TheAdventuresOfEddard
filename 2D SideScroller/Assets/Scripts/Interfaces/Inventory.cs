using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityInterfaces;
using Items;

public class Inventory : MonoBehaviour
{
    public List<Item> Items;

    public Inventory()
    {
        //_inventory = items.Where(x => x is IInventoryItem).Select(x => x as IInventoryItem).ToList();
        //_inventory = new List<IInventoryItem>();
    }
    public List<IEquipable> GetEquipableItems()
    {
        return Items.Where(x => x is IEquipable).Select(x => x as IEquipable).ToList();
    }
    public List<IWeapon> GetWeaponItems()
    {
        return Items.Where(x => x is IWeapon).Select(x => x as IWeapon).ToList();
    }
    public List<IConsumable> GetConsumableItems()
    {
        return Items.Where(x => x is IConsumable).Select(x => x as IConsumable).ToList();
    }
    //public void AddItemToInventory(IInventoryItem inventoryItem)
    //{
    //    _inventory.Add(inventoryItem);
    //}
    //public void RemoveInventoryItem(IInventoryItem inventoryItem)
    //{
    //    _inventory.Remove(inventoryItem);
    //}
}




