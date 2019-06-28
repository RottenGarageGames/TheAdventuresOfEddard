using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/New Item", fileName = "StackableItemName.asset")]
public class ItemData : ScriptableObject
{
    public int itemID;
    public string itemName;
    public string itemCategory;
    public int basePrice;
    public int sellValue;
    public int StackSize;
    public int MaxStackSize;
    public Sprite sprite;
    public string prefabPath;
    public GameObject itemPrefab;
    public Rarity rarity;

    public ItemData(ItemData itemData)
    {
        itemID = itemData.itemID;
        itemName = itemData.itemName;
        itemCategory = itemData.itemCategory;
        basePrice = itemData.basePrice;
        sellValue = itemData.sellValue;
        StackSize = itemData.StackSize;
        MaxStackSize = itemData.MaxStackSize;
        sprite = itemData.sprite;
        prefabPath = itemData.prefabPath;
        itemPrefab = itemData.itemPrefab;
        rarity = itemData.rarity;
    }

}


public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
