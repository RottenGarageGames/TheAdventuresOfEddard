using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/New Item Table", fileName = "StackableItemName.asset")]
public class ItemList : ScriptableObject
{
    public List<ItemData> itemDatas = new List<ItemData>();
}
