using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;
using Items;

public class Interact : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<IInteractable>() != null && Input.GetButtonDown("Interact"))
        {
            var interactableObject = collider.gameObject.GetComponent<IInteractable>();
            interactableObject.Interact(gameObject);

            if(collider.gameObject.GetComponent<IInventoryItem>() != null)
            {
                gameObject.GetComponent<PlayerInventory>().AddItem(collider.gameObject);
                collider.gameObject.SetActive(false);
            }
        }
    }
}
