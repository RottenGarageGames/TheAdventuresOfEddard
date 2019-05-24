using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class Coin : Stat, IInteractable
{
    [SerializeField]
    private float _interactRadius;
    public float interactRadius { get; set; }

    public void Interact(GameObject gameObject)
    {
        var purse = gameObject.GetComponent<Currency>();

        if(purse != null)
        {
            purse.IncreaseStat(stat);
        }
    }
}
