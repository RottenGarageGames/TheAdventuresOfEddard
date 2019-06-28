using System;
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

    public string Name;
    public ItemCategory[] Category;
    public int Price;
    public int Value;
    public int StackSize;
    public int MaxStackSize;
    public Sprite Sprite;
    public GameObject Prefab;
    public ItemRarity Rarity;

    public ItemData(ItemData itemData)
    {
        Name = itemData.Name;
        Category = itemData.Category;
        Price = itemData.Price;
        Value = itemData.Value;
        StackSize = itemData.StackSize;
        MaxStackSize = itemData.MaxStackSize;
        Sprite = itemData.Sprite;
        Prefab = itemData.Prefab;
        Rarity = itemData.Rarity;
    }

    
    //EditorGUILayout.MaskField("Player Flags", flags, options);
}