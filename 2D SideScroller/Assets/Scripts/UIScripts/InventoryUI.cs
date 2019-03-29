using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> inventorySlots;

    
    public void SetUISlot(Sprite itemSprite, int count)
    {
        foreach (GameObject item in inventorySlots)
        {
            if (item.GetComponent<Image>().sprite == null)
            {
                var currentSlot = item.GetComponent<Image>();
                var tempColor = currentSlot.color;
                tempColor.a = 1f;
                currentSlot.sprite = itemSprite;
                currentSlot.color = tempColor;

                if (count > 0)
                {
                    item.GetComponentInChildren<Text>().text = count.ToString();
                }
                break;
            }
        }
    }
}
