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
        public int MaxCount = 1;
        public Sprite Sprite;
        public Rarity Rarity;

        public override void Interact(GameObject player)
        {
            if (player.GetComponent<PlayerInventory>() != null)
            {
                var inventory = player.GetComponent<PlayerWheel>();

                inventory.AddItem(this);
                Destroy(gameObject);
            }
        }

        public abstract void Use(GameObject player);
    }
}

