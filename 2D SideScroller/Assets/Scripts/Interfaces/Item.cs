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
        public String OnStartItemName;
        public String itemName { get; set; }

        [SerializeField]
        public String PrefabPath;
        public String prefabPath { get; set; }

        [SerializeField]
        public int OnStartBasePrice;
        public int basePrice { get; set; }

        [SerializeField]
        public int OnStartItemID;
        public int itemID { get; set; }

        [SerializeField]
        public float OnStartInteractRadius;
        public float interactRadius { get; set; }

        [SerializeField]
        public Sprite sprite { get; set; }

        private void Start()
        {
            itemName = OnStartItemName;
            itemID = OnStartItemID;
            interactRadius = OnStartInteractRadius;
            _circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
            _circleCollider2D.radius = OnStartInteractRadius;
            sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        public Item()
        {
            
        }
        public void Interact(GameObject gameObject)
        {
            
        }
    }
}

