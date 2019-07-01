using Items;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class Chest : Interactable
{
    public bool Unused = true;

    public override void Interact(GameObject interactingObject)
    {
        if (Unused)
        {
            Unused = false;
            var wheel = interactingObject.GetComponent<PlayerWheel>();
            //wheel.AddItem(new HealthPotion());
            Spawner.SpawnRandomItem(new List<GameObject> { Resources.Load("HealthPotion") as GameObject }, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y));
        }

        Destroy(gameObject);
    }
}
