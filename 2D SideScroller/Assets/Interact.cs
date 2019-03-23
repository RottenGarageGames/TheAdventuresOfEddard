using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class Interact : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<IInteractable>() != null && Input.GetButtonDown("Interact"))
        {
           
        }
    }
}
