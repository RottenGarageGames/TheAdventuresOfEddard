using System;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/New Item", fileName = "Item.asset")]
public class ItemData : ScriptableObject
{
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