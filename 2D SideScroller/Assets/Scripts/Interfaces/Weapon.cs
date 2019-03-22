using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;
using System;

public class Weapon : IInventoryItem, IWeapon, IEquipable
{
    public String name { get; set; }
    public int damage { get; set; }
    public int itemID { get; set; }

    public Weapon()
    {

    }
    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }
    public void Equip()
    {

    }
}

