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
        if(interactable.GetComponent<IInteractable>() != null && Input.GetButtonDown("LeftThumbButton") && interactable.activeInHierarchy)
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
                    var itemComponent = collider.gameObject.GetComponent<Item>();
                    if (gameObject.GetComponent<PlayerInventory>().AddItem(itemComponent.Data))
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
        if (interactable.GetComponent<IAutoInteract>() != null)
        {
          if(gameObject.transform.position.x - interactable.gameObject.transform.position.x < 1)
            {
                if(interactable.gameObject.GetComponent<Coin>() != null)
                {
                        var coin = interactable.gameObject.GetComponent<Coin>();
                        coin.AddToPurse(gameObject);
                        interactable.gameObject.GetComponent<Coin>().AddToPurse(gameObject);
                }

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collidedObject = collision.gameObject;

        if(collidedObject.GetComponent<IAutoInteract>() != null)
        {
            var autoInteractable = collidedObject.GetComponent<IAutoInteract>();
            autoInteractable.Interact(gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var collidedObject = collision.gameObject;

        if (collidedObject.GetComponent<IAutoInteract>() != null)
        {
            var autoInteractable = collidedObject.GetComponent<IAutoInteract>();


            if (collidedObject.GetComponent<AutoPickUp>().target.gameObject == gameObject)
            {
                collidedObject.GetComponent<AutoPickUp>().RemoveTarget(gameObject);
            }
        }
    }

}
