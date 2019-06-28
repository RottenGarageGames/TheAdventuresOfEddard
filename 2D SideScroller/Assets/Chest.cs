using UnityEngine;
using UnityInterfaces;

public class Chest : Interactable
{
    public ItemList chestDropList;
    public DropRates DropRates;

    public bool Unused = true;

    public override void Interact(GameObject interactingObject)
    {
        Debug.Log("Fligging is called.");
        if (Unused)
        {
            Unused = false;        
            Spawner.SpawnRandomItem(chestDropList, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y));
        }

        Destroy(gameObject);
    }
}
