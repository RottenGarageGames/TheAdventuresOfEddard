using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class Chest : MonoBehaviour, IInteractable
{
    public ItemList chestDropList;
    public float CurrencyDropRate;
    public float ItemDropRate;
    public float RareItemDrop;
    public float MultipleItemDropRate;
    // Start is called before the first frame update

    public void Interact(GameObject interactingObject)
    {
        Spawner.SpawnRandomItem(chestDropList, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y));

        Destroy(gameObject);
    }
}
