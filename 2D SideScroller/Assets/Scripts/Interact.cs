using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;
using Items;

public class Interact : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {
        var interactable = collider.gameObject;
        if(interactable.GetComponent<IInteractable>() != null && Input.GetButtonDown("Interact") && interactable.activeInHierarchy)
        {
            //Call the default interact function
            var interactableObject = interactable.GetComponent<IInteractable>();
            interactableObject.Interact(gameObject);

            //If the interactable is an inventory item, pick up the object
            if(interactable.GetComponent<IInventoryItem>() != null)
            {

                // Take the object out of scene
                interactable.SetActive(false);

                // Add the item to player inventory if the interacting component has an inventory component
                if (gameObject.GetComponent<PlayerInventory>() != null)
                {
                    if(gameObject.GetComponent<PlayerInventory>().AddItem(collider.gameObject.GetComponent<Item>()))
                    {
                        //The item was added to the inventory
                    }
                    else
                    {
                        //Place the item back in the scene
                        //interactable.SetActive(true);
                    }
                }

            }
        }
    }
}
