using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/New Item", fileName = "StackableItemName.asset")]
public class ItemData : ScriptableObject
{
    public enum ItemCategory
    {
        Potion,
        Weapon
    };

    public enum ItemRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    };

    public int ID;
    public string Name;
    public ItemCategory[] Category;
    public int Price;
    public int Value;
    public int StackSize;
    public int MaxStackSize;
    public int ChestMaxStackSize;
    public Sprite Sprite;
    public GameObject Prefab;
    public ItemRarity Rarity;
    public bool Craftable;
    public List<CraftingIngredient> Recipe = new List<CraftingIngredient>();

    public ItemData(ItemData itemData)
    {
        ID = itemData.ID;
        Name = itemData.Name;
        Category = itemData.Category;
        Price = itemData.Price;
        Value = itemData.Value;
        StackSize = itemData.StackSize;
        MaxStackSize = itemData.MaxStackSize;
        Sprite = itemData.Sprite;
        Prefab = itemData.Prefab;
        Rarity = itemData.Rarity;
        Craftable = itemData.Craftable;
    }

    
    //EditorGUILayout.MaskField("Player Flags", flags, options);
}