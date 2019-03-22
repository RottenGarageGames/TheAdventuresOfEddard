using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;
using System;

public class Item : IInventoryItem
{
    public String name { get; set; }
    public int itemID { get; set; }

    public Item()
    {

    }
}

