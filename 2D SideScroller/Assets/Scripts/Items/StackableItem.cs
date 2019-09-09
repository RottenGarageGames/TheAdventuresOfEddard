using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;
using Items;

public class StackableItem : Item, IStackable
{
    public ItemData data;

    private void Awake()
    {
        Data = data;
    }
    public void DecreaseCount(int amount)
    {
        Data.StackSize -= amount;
    }
    public void IncreaseCount(int amount)
    {
        Data.StackSize += amount;
    }
}
