using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class Chest : MonoBehaviour, IInteractable
{
    public ItemList chestDropList;
    public DropRates DropRates;

    public bool Unused = true;
    // Start is called before the first frame update

    public void Interact(GameObject interactingObject)
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
