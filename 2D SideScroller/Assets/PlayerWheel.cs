using Items;
using UnityEngine;

public class PlayerWheel : MonoBehaviour
{
    public InventorySlot Slot1;
    public InventorySlot Slot2;
    public InventorySlot Slot3;
    public InventorySlot Slot4;
    public InventorySlot Slot5;

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
        if (Slot1.Item.GetType() == item.GetType())
        {
            Slot1.AddItem(item);
        }
        else if (Slot2.Item.GetType() == item.GetType())
        {
            Slot2.AddItem(item);
        }
        else if (Slot3.Item.GetType() == item.GetType())
        {
            Slot3.AddItem(item);
        }
        else if (Slot4.Item.GetType() == item.GetType())
        {
            Slot4.AddItem(item);
        }
        else if (Slot5.Item.GetType() == item.GetType())
        {
            Slot5.AddItem(item);
        }
        else
        {
            Debug.Log($"There was not enough space in your inventory for {item.Name}");
        }
    }
}
