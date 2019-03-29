using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;
using Items;

public class StackableItem : Item, IStackable
{
    public int MaxStack;
    public int StackSize { get; set; }
    public int MaxStackSize { get; set; }

    void Awake()
    {
        MaxStackSize = MaxStack;
    }

    public void DecreaseCount(int amount)
    {
        StackSize--;
    }
    public void IncreaseCount(int amount)
    {
        StackSize++;
    }
}
