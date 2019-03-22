using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;
using System;

namespace Items
{
    public class Item : MonoBehaviour, IInventoryItem
    {
        [SerializeField]
        private String _name;
        public String name { get { return _name; } set { _name = value; _name = value; } }
        [SerializeField]
        private int _itemID;
        public int itemID { get { return _itemID; } set { _itemID = value; itemID = value; } }

        public Item()
        {

        }
    }
}

