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
        private String _itemName;
        public String itemName { get; set; }

        [SerializeField]
        private int _itemID;
        public int itemID { get; set; }

        [SerializeField]
        private float _interactRadius;
        public float interactRadius { get; set; }

        [SerializeField]
        public Sprite sprite { get; set; }

        private void Start()
        {
            //itemName = _itemName;
            //itemID = _itemID;
            //interactRadius = _interactRadius;
            //_circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
            //_circleCollider2D.radius = _interactRadius;
            //sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        public Item()
        {
            
        }
        public void Interact(GameObject gameObject)
        {
            
        }
    }
}

