using UnityEngine;
using UnityInterfaces;

namespace Items
{
    public class Item : Interactable
    {
        public ItemData Data { get; set; }
 
        public override void Interact(GameObject player)
        {
            if (player.GetComponent<PlayerInventory>() != null)
            {
                var inventory = player.GetComponent<PlayerInventory>();

                if (inventory.ItemCanBeAdded(Data))
                {
                    inventory.AddItem(Data);
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Inventory is full. Item can't be added");
                }
            }
        }
    }
}

