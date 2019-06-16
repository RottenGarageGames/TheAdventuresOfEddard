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
        public ItemData Data { get; set; }
 

        private void Start()
        {
        }
        public Item()
        {
            
        }
        public void Interact(GameObject interactable)
        {

        }
    }
}

