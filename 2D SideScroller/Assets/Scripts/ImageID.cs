using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageID : MonoBehaviour
{

    public InventoryUI inventoryUI;
    public ItemData itemData;

    public void UseItem()
    {
            inventoryUI.UseItem(itemData.Name, gameObject);
    }
}
