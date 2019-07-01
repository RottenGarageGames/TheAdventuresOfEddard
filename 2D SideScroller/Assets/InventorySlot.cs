using Items;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image Image;
    public Text CountText;

    public Item Item;
    public int Count;

    public void AddItem(Item item)
    {
        if(Item is null)
        {
            Item = item;
            Debug.Log($"{Item.Name} was added to your inventory.");
        }
        else if(Item.GetType() != item.GetType())
        {
            Debug.Log($"Could not add item of type {item.GetType().ToString()} to this inventory slot.");
        }
        else if(Count == Item.MaxCount)
        {
            Debug.Log($"You already have the max number of {Item.Name}'s!");
        }
        else
        {
            Count++;
            CountText.text = Count.ToString();
            Debug.Log($"{Item.Name} was added to your inventory.");
        }
    }
}
