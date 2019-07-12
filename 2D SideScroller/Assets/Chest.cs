using Items;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class Chest : Interactable
{
    public bool Open = false;

    public override void Interact(GameObject interactingObject)
    {
        if (!Open)
        {
            //Open = true;
            var controller = interactingObject.GetComponent<CalebPlayerController>();
            var playerInventory = controller.PlayerInventory;

            var item = Resources.Load("Items/HealthPotion") as GameObject;

            playerInventory.AddItem(item.GetComponent<Item>());
            Spawner.SpawnRandomItem(new List<GameObject> { item }, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y));
        }
    }
}
