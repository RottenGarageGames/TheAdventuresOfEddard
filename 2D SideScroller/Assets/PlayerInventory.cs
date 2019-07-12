using Items;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<InventorySlot> Slots;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void AddItem(Item item)
    {
        foreach(var slot in Slots)
        {
            if (slot.TryAddItem(item))
            {
                Debug.Log($"Added {item.Name} to your inventory!");

                return;
            }
        }

        Debug.Log($"There was not enough space in your inventory for {item.Name}.");
    }
}
