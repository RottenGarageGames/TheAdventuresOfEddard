using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingImageID : ImageID
{
    public void CraftItem()
    {
        inventoryUI.CraftItem(itemData);
    }
}
