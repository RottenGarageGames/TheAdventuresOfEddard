using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityInterfaces;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<IInventoryItem> _inventory;

    public Inventory()
    {
        _inventory = new List<IInventoryItem>();
    }
    public List<IEquipable> GetEquipableItems()
    {
        return _inventory.Where(x => x is IEquipable).Select(x => x as IEquipable).ToList();
    }
    public List<IWeapon> GetWeaponItems()
    {
        return _inventory.Where(x => x is IWeapon).Select(x => x as IWeapon).ToList();
    }
    public List<IConsumable> GetConsumableItems()
    {
        return _inventory.Where(x => x is IConsumable).Select(x => x as IConsumable).ToList();
    }
    public void AddItemToInventory(IInventoryItem inventoryItem)
    {
        _inventory.Add(inventoryItem);
    }
    public void RemoveInventoryItem(IInventoryItem inventoryItem)
    {
        _inventory.Remove(inventoryItem);
    }
}




