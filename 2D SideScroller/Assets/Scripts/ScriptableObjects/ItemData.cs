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
}
