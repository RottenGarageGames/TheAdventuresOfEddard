using Items;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image Image;
    public Text CountText;

    public Item Item;
    public int Count;

    public bool TryAddItem(Item item)
    {
        if (Item is null)
        {
            Item = item;

            Count = 1;

            CountText.text = Count.ToString();

            Image.sprite = item.Sprite;

            return true;
        }

        if(item.GetType() == Item.GetType() && Count < item.MaxCount)
        {
            Count++;

            CountText.text = Count.ToString();

            return true;
        }

        return false;
    }
}
