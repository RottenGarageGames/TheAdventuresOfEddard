using UnityEngine;
using UnityInterfaces;

namespace Items
{
    public enum Type { Weapon, Wearable };

    public enum Rarity { Common, Uncommon, Rare, Epic, Legendary };

    public abstract class Item : Interactable
    {
        public string Name;
        public Type Type;
        public int Price;
        public int Value;
        public bool CanStack;
        public int Count;
        public Sprite Sprite;
        public Rarity Rarity;

        public override void Interact(GameObject player)
        {
            if (player.GetComponent<PlayerInventory>() != null)
            {
                var inventory = player.GetComponent<PlayerInventory>();

                if (inventory.AddItem(this))
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

        public abstract void Use(GameObject player);
    }
}

