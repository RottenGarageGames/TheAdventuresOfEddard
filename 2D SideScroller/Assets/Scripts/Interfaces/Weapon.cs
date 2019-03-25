using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;
using System;
using Items;

public class Weapon : Item, IWeapon, IEquipable
{
    public int damage { get; set; }

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

