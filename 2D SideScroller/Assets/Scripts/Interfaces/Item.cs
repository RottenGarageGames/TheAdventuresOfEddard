using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;
using System;
using UnityEngine.Events;

namespace Items
{
    public class Item : MonoBehaviour, IInventoryItem, IInteractable
    {
        private CircleCollider2D _circleCollider2D;

        public UnityEvent equipItem;
        [SerializeField]
        private String _name;
        public String name { get { return _name; } set { _name = value; _name = value; } }

        [SerializeField]
        private int _itemID;
        public int itemID { get { return _itemID; } set { _itemID = value; itemID = value; } }

        [SerializeField]
        private float _interactRadius;
        public float interactRadius { get { return _interactRadius; } set { _interactRadius = value; interactRadius = value; } }
        void Awake()
        {
            _circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
            _circleCollider2D.radius = _interactRadius;
        }
        public Item()
        {
            
        }
        public void Interact(GameObject gameObject)
        {
            
        }
    }
}

