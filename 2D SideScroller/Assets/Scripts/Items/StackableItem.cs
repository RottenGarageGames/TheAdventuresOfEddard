using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;
using Items;

public class StackableItem : Item, IStackable
{
    [SerializeField]
    private int _StackSize;
    public int StackSize { get; set; }

    [SerializeField]
    private int _MaxStackSize;
    public int MaxStackSize { get; set; }

    [SerializeField]
    private int _AddSize;
    public int AddSize { get; set; }

    void Awake()
    {
        StackSize = _StackSize;
        MaxStackSize = _MaxStackSize;
        AddSize = _AddSize;
    }

    public void DecreaseCount(int amount)
    {
        StackSize -= amount;
    }
    public void IncreaseCount(int amount)
    {
        StackSize += amount;
    }
}
