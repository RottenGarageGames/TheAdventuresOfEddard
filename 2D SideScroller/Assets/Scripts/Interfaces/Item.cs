using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;
using System;

namespace Items
{
    public class Item : MonoBehaviour, IInventoryItem, IInteractable
    {
        [SerializeField]
        private String _name;
        public String name { get { return _name; } set { _name = value; _name = value; } }

        [SerializeField]
        private int _itemID;
        public int itemID { get { return _itemID; } set { _itemID = value; itemID = value; } }

        [SerializeField]
        private int _interactRadius;
        public int interactRadius { get { return _interactRadius; } set { _interactRadius = value; interactRadius = value; } }

        public Item()
        {

        }
        public void Interact()
        {

        }
    }
}

